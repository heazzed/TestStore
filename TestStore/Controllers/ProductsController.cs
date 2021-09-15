using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestStore.Entities;
using TestStore.EntitiesDto;
using TestStore.Models;
using TestStore.Services;

namespace TestStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        readonly ProductService productService;

        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto) // +
        {
            return StatusCode(await productService.CreateProductAsync(productDto));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProductsAsync(string categoryId = null) // +
        {
            return await productService.GetProductsAsync(categoryId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(string id) // +
        {
            return await productService.GetProductByIdAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateProductByIdAsync([FromBody] ProductDto productDto) // +
        {
            return StatusCode(await productService.UpdateProductByIdAsync(productDto));
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PatchProductByIdAsync([FromBody] ProductDto productDto) // +
        {
            return StatusCode(await productService.PatchProductByIdAsync(productDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProductByIdAsync(string id) // +
        {
            return StatusCode(await productService.DeleteProductByIdAsync(id));
        }
    }
}

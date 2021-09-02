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
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            return StatusCode(await productService.CreateProductAsync(product));
        }

        [HttpGet]
        public IActionResult GetProducts(string categoryId)
        {
            return Json(productService.GetProducts(categoryId));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(string id)
        {
            return Json(productService.GetProductById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProductByIdAsync([FromBody] Product product)
        {
            return StatusCode(await productService.UpdateProductByIdAsync(product));
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PatchProductByIdAsync([FromBody] Product product)
        {
            return StatusCode(await productService.PatchProductByIdAsync(product));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync(string id)
        {
            return StatusCode(await productService.DeleteProductByIdAsync(id));
        }
    }
}

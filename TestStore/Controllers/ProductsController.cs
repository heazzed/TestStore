using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestStore.Entities;
using TestStore.Models;
using TestStore.Services;

namespace TestStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("FrontentOrigins")]
    public class ProductsController : Controller
    {
        ProductService productService;

        public ProductsController(ProductService productService)
        {
            this.productService = productService;
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
        public async Task UpdateProductById(string id)
        {
            var reqBody = HttpContext.Request.Body;
            using (StreamReader reader = new StreamReader(reqBody))
            {
                var body = await reader.ReadToEndAsync(); // json from front with new productinfo to update in DB

                // TODO
                // Make logic to parse json and update DB productinfo
            } 
             
        }
    }
}

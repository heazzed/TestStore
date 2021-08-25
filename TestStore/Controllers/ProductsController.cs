using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestStore.Entities;
using TestStore.Models;

namespace TestStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("MyAllowSpecificOrigins")]
    //[EnableCors("AllowAllOrigins")]
    public class ProductsController : Controller
    {
        StoreContext db;

        public ProductsController(StoreContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Product> products = new List<Product>();

            foreach (var item in db.Products)
            {
                products.Add(item);
            }

            return Json(products);
        }

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Get(string categoryId)
        //{
        //    return View();
        //}
    }
}

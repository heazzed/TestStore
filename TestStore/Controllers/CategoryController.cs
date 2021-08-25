using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestStore.Entities;
using TestStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("MyAllowSpecificOrigins")]
    //[EnableCors("AllowAllOrigins")]
    public class CategoryController : Controller
    {
        StoreContext db;

        public CategoryController(StoreContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = new List<Category>();

            foreach (var item in db.Categories)
            {
                categories.Add(item);
            }

            return Json(categories);
        }
    }
}

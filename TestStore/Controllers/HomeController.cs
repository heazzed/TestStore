using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            string fname = "John";

            string sname = "Anna";

            List<string> names = new List<string>();

            names.Add(fname);

            names.Add(sname);

            return Json(names);
        }
    }
}

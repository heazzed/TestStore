using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        readonly OrderService orderService;

        public OrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Json(orderService.GetOrders());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrderById(string id)
        {
            return Json(orderService.GetOrderById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync()
        {
            return StatusCode(await orderService.CreateOrdersAsync(HttpContext.Request));
        }
    }
}

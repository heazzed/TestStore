using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStore.Entities;
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
        public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
        {
            return StatusCode(await orderService.CreateOrderAsync(order));
        }

        [HttpPatch]
        [Route("~/[controller]/{id}")]
        public async Task<IActionResult> PatchOrderByIdAsync([FromRoute] string id, [FromBody] Order order)
        {
            return StatusCode(await orderService.PatchOrderByIdAsync(id, order));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderByIdAsync(string id)
        {
            return StatusCode(await orderService.DeleteOrderByIdAsync(id));
        }
    }
}

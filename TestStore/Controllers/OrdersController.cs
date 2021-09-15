using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStore.Entities;
using TestStore.EntitiesDto;
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
        public async Task<ActionResult<List<OrderDto>>> GetOrdersAsync() // +
        {
            return await orderService.GetOrdersAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync(string id) // +
        {
            return await orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderAsync([FromBody] OrderDto orderDto) // +
        {
            return StatusCode(await orderService.CreateOrderAsync(orderDto));
        }

        [HttpPatch]
        [Route("~/[controller]/{id}")]
        public async Task<ActionResult> PatchOrderByIdAsync([FromRoute] string id, [FromBody] OrderDto orderDto) // +
        {
            return StatusCode(await orderService.PatchOrderByIdAsync(id, orderDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteOrderByIdAsync(string id) // +
        {
            return StatusCode(await orderService.DeleteOrderByIdAsync(id));
        }
    }
}

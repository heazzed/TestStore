using System;
using System.Linq;
using TestStore.Entities;
using TestStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TestStore.Services
{
    public class OrderService
    {
        readonly StoreContext db;

        public OrderService(StoreContext db)
        {
            this.db = db;
        }

        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        public async Task<int> CreateOrdersAsync(HttpRequest httpRequest)
        {
            using StreamReader reader = new StreamReader(httpRequest.Body);

            var body = await reader.ReadToEndAsync();

            Order order = JsonConvert.DeserializeObject<Order>(body);

            var ordersMaxId = db.Orders.Max(x => x.Id);

            order.Id = ordersMaxId + "1"; // Need to generate Id's

            await db.Orders.AddAsync(order);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }

        public Order GetOrderById(string id)
        {
            return db.Orders.Include(o => o.Client).Include(o => o.Products).FirstOrDefault(o => o.Id == id);
        }
    }
}

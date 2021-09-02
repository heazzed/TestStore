using System;
using System.Linq;
using TestStore.Entities;
using TestStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

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
            return db.Orders.Include(op => op.Products).Include(c => c.Client);
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
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

        public async Task<int> PatchOrderByIdAsync(string id, Order order)
        {
            var dbOrder = await db.Orders.SingleOrDefaultAsync(o => o.Id == id);

            dbOrder.Status = order.Status;

            db.Update(dbOrder);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }

        public async Task<int> DeleteOrderByIdAsync(string id)
        {
            var dbOrder = await db.Orders.SingleOrDefaultAsync(o => o.Id == id);

            var dbOrderProducts = db.OrderProducts.FirstOrDefault(op => op.OrderId == id);

            db.OrderProducts.Remove(dbOrderProducts);

            db.Orders.Remove(dbOrder);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }
    }
}

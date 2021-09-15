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
using TestStore.EntitiesDto;
using AutoMapper;
using System.Collections.Generic;

namespace TestStore.Services
{
    public class OrderService
    {
        readonly StoreContext db;

        readonly IMapper mapper;

        public OrderService(StoreContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<OrderDto>> GetOrdersAsync() // +
        {
            var orders = await db.Orders.Include(op => op.Products).Include(c => c.Client).ToListAsync();

            List<OrderDto> ordersDto = new List<OrderDto>();

            foreach (var item in orders)
            {
                var orderDto = mapper.Map<Order, OrderDto>(item);

                ordersDto.Add(orderDto);
            }

            return ordersDto;
        }

        public async Task<int> CreateOrderAsync(OrderDto orderDto) // +
        {
            var order = mapper.Map<Order>(orderDto);

            order.Id = Guid.NewGuid();

            await db.Orders.AddAsync(order);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }

        public async Task<OrderDto> GetOrderByIdAsync(string id) // +
        {
            var order = await db.Orders.Include(o => o.Client).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id.ToString() == id);

            var orderDto = mapper.Map<OrderDto>(order);

            foreach (var item in orderDto.Products)
            {
                var product = await db.Products.FirstOrDefaultAsync(p => p.Id.ToString() == item.Id);

                item.Img = product.Img;

                item.Name = product.Name;

                item.Description = product.Description;

                item.Price = product.Price;

                item.CategoryId = product.CategoryId.ToString();
            }

            return orderDto;
        }

        public async Task<int> PatchOrderByIdAsync(string id, OrderDto orderDto) // +
        {
            var order = await db.Orders.SingleOrDefaultAsync(o => o.Id.ToString() == id);

            order.Status = orderDto.Status;

            db.Update(order);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }

        public async Task<int> DeleteOrderByIdAsync(string id) // +
        {
            var dbOrder = await db.Orders.SingleOrDefaultAsync(o => o.Id.ToString() == id);

            var dbOrderProducts = db.OrderProducts.FirstOrDefault(op => op.OrderId.ToString() == id); 
     
            db.OrderProducts.Remove(dbOrderProducts);

            db.Orders.Remove(dbOrder);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }
    }
}

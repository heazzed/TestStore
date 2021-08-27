using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Entities;
using TestStore.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TestStore.Controllers
{
    // TEST CONTROLLER

    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        StoreContext context;

        public HomeController(StoreContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            string fname = "John";

            string sname = "Anna";

            List<string> names = new List<string>();

            names.Add(fname);

            names.Add(sname);

            return Json(names);
        }

        public IActionResult CreateCategory(string id)
        {
            // Hardcode category

            Category category = new Category
            {
                Id = id,
                Name = "Orange",
                Description = "Here will be orange products",
                Img = "category3.jpg"
            };

            context.Categories.Add(category);

            context.SaveChanges();

            return Json(category);
        }

        public IActionResult CreateProduct(string id)
        {
            // Hardcode product

            Product product = new Product
            {
                Id = id,
                CategoryId = "2",
                Img = "product3.jpg",
                Name = "New Apple",
                Description = "Red Apple",
                Pieces = 34,
                Price = 52
            };

            product.Category = context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

            context.Products.Add(product);

            context.SaveChanges();

            return Json(product);
        }

        public IActionResult CreateOrder(string id, Order.StatusEnum status)
        {
            // Create order

            Order order = new Order
            {
                Id = id,
                Status = status.ToString()
            };

            // Hardcode client

            Client client = new Client
            {
                FirstName = "Andrew",
                LastName = "Some",
                Address = "Blackberry street",
                Phone = "12347972",
                Email = "andrew@email.com",
                OrderId = order.Id,
            };

            // Hardcode products

            Product product1 = context.Products.FirstOrDefault(x => x.Id == "1");

            Product product2 = context.Products.FirstOrDefault(x => x.Id == "2");

            Product product3 = context.Products.FirstOrDefault(x => x.Id == "3");

            // Make order products to save info in DB

            OrderProduct orderProduct1 = new OrderProduct
            {
                OrderId = order.Id,
                ProductId = product1.Id,
                Order = order,
                Product = product1
            };

            OrderProduct orderProduct2 = new OrderProduct
            {
                OrderId = order.Id,
                ProductId = product2.Id,
                Order = order,
                Product = product2
            };

            OrderProduct orderProduct3 = new OrderProduct
            {
                OrderId = order.Id,
                ProductId = product3.Id,
                Order = order,
                Product = product3
            };

            // Make array order products

            OrderProduct[] orderProducts = new OrderProduct[3];
            orderProducts[0] = orderProduct1;
            orderProducts[1] = orderProduct2;
            orderProducts[2] = orderProduct3;


            // Complete info about order

            order.Client = client;
            order.Products = orderProducts;


            // Save to DB

            context.Clients.Add(client);

            context.Orders.Add(order);

            context.OrderProducts.Add(orderProduct1);

            context.OrderProducts.Add(orderProduct2);

            context.OrderProducts.Add(orderProduct3);

            context.SaveChanges();

            

            return Json(order);
        }

    }
}

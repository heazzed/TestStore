using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestStore.Entities;
using TestStore.Models;

namespace TestStore.Services
{
    public class ProductService
    {
        readonly StoreContext db;

        public ProductService(StoreContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetProducts(string categoryId = null)
        {
            return categoryId == null ? db.Products : db.Products.Where(p => p.CategoryId == categoryId);
        }

        public Product GetProductById(string id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<int> UpdateProductByIdAsync(HttpRequest httpRequest)
        {
            using StreamReader reader = new StreamReader(httpRequest.Body);

            var body = await reader.ReadToEndAsync();

            Product updateProduct = JsonConvert.DeserializeObject<Product>(body);

            var dbProduct = db.Products.FirstOrDefault(p => p.Id == updateProduct.Id);

            dbProduct.Pieces = updateProduct.Pieces;

            db.Update(dbProduct); // Need it?

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
                // Right code 502? // Must I return status code at all?
        }
    }
}

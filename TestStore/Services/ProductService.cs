using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}

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

        public async Task<int> CreateProductAsync(Product product)
        {
            product.Id = db.Products.Max(p => p.Id) + "1"; // Need to Generate Id

            await db.Products.AddAsync(product);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }


        public IQueryable<Product> GetProducts(string categoryId = null)
        {
            return categoryId == null ? db.Products : db.Products.Where(p => p.CategoryId == categoryId);
        }

        public Product GetProductById(string id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<int> UpdateProductByIdAsync(Product updateProduct)
        {
            var dbProduct = db.Products.FirstOrDefault(p => p.Id == updateProduct.Id);

            dbProduct.Pieces = updateProduct.Pieces;

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
            // Right code 502? // Must I return status code at all?
        }

        public async Task<int> PatchProductByIdAsync(Product patchProduct)
        {
            var dbProduct = db.Products.FirstOrDefault(p => p.Id == patchProduct.Id);

            // TODO Logic how to patch

            if (patchProduct.Img != dbProduct.Img)
            {
                dbProduct.Img = patchProduct.Img;
            }

            if (patchProduct.CategoryId != dbProduct.CategoryId)
            {
                dbProduct.CategoryId = patchProduct.CategoryId;
            }

            if (patchProduct.Name != dbProduct.Name)
            {
                dbProduct.Name = patchProduct.Name;
            }

            if (patchProduct.Description != dbProduct.Description)
            {
                dbProduct.Description = patchProduct.Description;
            }

            if (patchProduct.Pieces != dbProduct.Pieces)
            {
                dbProduct.Pieces = patchProduct.Pieces;
            }

            if (patchProduct.Price != dbProduct.Price)
            {
                dbProduct.Price = patchProduct.Price;
            }

            // Make to switch?  Or make smth anoter?

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }

        public async Task<int> DeleteProductByIdAsync(string id)
        {
            var dbProduct = db.Products.FirstOrDefault(p => p.Id == id);

            db.Products.Remove(dbProduct);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        } 
    }
}

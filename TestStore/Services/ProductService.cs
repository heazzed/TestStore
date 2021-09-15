using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestStore.Entities;
using TestStore.EntitiesDto;
using TestStore.Models;

namespace TestStore.Services
{
    public class ProductService
    {
        readonly StoreContext db;

        readonly IMapper mapper;

        public ProductService(StoreContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<int> CreateProductAsync(ProductDto productDto) // +
        {
            var product = mapper.Map<Product>(productDto);

            product.Id = Guid.NewGuid();

            await db.Products.AddAsync(product);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        }


        public async Task<List<ProductDto>> GetProductsAsync(string categoryId) // +
        {
            var products = categoryId == null ? await db.Products.ToListAsync() : 
                await db.Products.Where(p => p.CategoryId.ToString() == categoryId).ToListAsync();
            
            List<ProductDto> productsDto = new List<ProductDto>();

            foreach (var item in products)
            {
                ProductDto productDto = mapper.Map<Product, ProductDto>(item);
                productsDto.Add(productDto);
            }

            return productsDto;
        }

        public async Task<ProductDto> GetProductByIdAsync(string id) // +
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id.ToString() == id);

            var productDto = mapper.Map<Product, ProductDto>(product);

            return productDto;
        }

        public async Task<int> UpdateProductByIdAsync(ProductDto updateProductDto) // +
        {
            var dbProduct = await db.Products.FirstOrDefaultAsync(p => p.Id.ToString() == updateProductDto.Id);

            dbProduct.Pieces = updateProductDto.Pieces;

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
            // Right code 502? // Must I return status code at all?
        }

        public async Task<int> PatchProductByIdAsync(ProductDto patchProductDto) // +
        {
            var dbProduct = await db.Products.FirstOrDefaultAsync(p => p.Id.ToString() == patchProductDto.Id);

            var patchProduct = mapper.Map<Product>(patchProductDto);

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

        public async Task<int> DeleteProductByIdAsync(string id) // +
        {
            var dbProduct = await db.Products.FirstOrDefaultAsync(p => p.Id.ToString() == id);

            db.Products.Remove(dbProduct);

            var result = await db.SaveChangesAsync();

            return result == 0 ? StatusCodes.Status502BadGateway : StatusCodes.Status200OK;
        } 
    }
}

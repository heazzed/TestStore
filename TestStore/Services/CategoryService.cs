using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Entities;
using TestStore.EntitiesDto;
using TestStore.Models;

namespace TestStore.Services
{
    public class CategoryService
    {
        readonly StoreContext db;

        readonly IMapper mapper;

        public CategoryService(StoreContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync() // + 
        {
            var categories = await db.Categories.ToListAsync();

            List<CategoryDto> categoriesDto = new List<CategoryDto>();

            foreach (var item in categories)
            {
                var categoryDto = mapper.Map<Category, CategoryDto>(item);

                categoriesDto.Add(categoryDto);
            }

            return categoriesDto;
        }
    }
}

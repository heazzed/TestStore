using System;
using System.Linq;
using TestStore.Entities;
using TestStore.Models;

namespace TestStore.Services
{
    public class CategoryService
    {
        readonly StoreContext db;

        public CategoryService(StoreContext db)
        {
            this.db = db;
        }

        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TestStore.Entities;

namespace TestStore.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    }
}

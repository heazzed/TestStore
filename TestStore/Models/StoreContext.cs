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

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id); // Need it? Set Id prop by default

            modelBuilder.Entity<Client>().HasKey(c => c.OrderId);

            modelBuilder.Entity<User>().HasKey(u => u.Email);
        }
    }
}

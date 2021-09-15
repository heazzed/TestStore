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
            modelBuilder.Entity<Client>().HasKey(c => c.OrderId);

            modelBuilder.Entity<User>().HasKey(u => u.Email);

            modelBuilder.Entity<OrderProduct>().HasKey( op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
               .HasOne(op => op.Order)
               .WithMany(o => o.Products)
               .HasForeignKey(k => k.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(k => k.ProductId);
        }
    }
}

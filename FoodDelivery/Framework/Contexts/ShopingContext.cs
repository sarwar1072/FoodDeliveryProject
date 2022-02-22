using Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Contexts
{
    public class ShopingContext : DbContext, IShopingContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public ShopingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Product>()
            //    .HasMany(p => p.Images)
            //    .WithOne(i => i.Product);

            //builder.Entity<ProductCategory>()
            //    .HasOne(pc => pc.Product)
            //    .WithMany(p => p.Categories)
            //    .HasForeignKey(pc => pc.ProductId);

            //builder.Entity<ProductCategory>()
            //    .HasOne(pc => pc.Category)
            //    .WithMany(c => c.Categories)
            //    .HasForeignKey(pc => pc.CategoryId);

            //builder.Entity<Category>()
            //    .HasData(new DataSeed().Categories);

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

    }
}

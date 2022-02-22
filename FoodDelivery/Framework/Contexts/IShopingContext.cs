using Framework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Framework.Contexts
{
    public interface IShopingContext
    {
         DbSet<Category> Categories { get; set; }
         DbSet<Item> Items { get; set; }
         DbSet<ItemType> ItemTypes { get; set; }
         DbSet<Order> Orders { get; set; }
         DbSet<OrderItem> OrderItems { get; set; }
         DbSet<Cart> Carts { get; set; }
         DbSet<CartItem> CartItems { get; set; }
         DbSet<Address> Address { get; set; }
         DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
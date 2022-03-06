using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using Framework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Repositories
{
   public class CartRepository:Repository<Cart,int ,ShopingContext>,ICartRepository
    {
        private ShopingContext shopingContext 
        {
            get 
            {
                return _dbContext as ShopingContext;
            }
                
        }
        public CartRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
        public Cart GetCart(int CartId)
        {

            return shopingContext.Carts.Include(x=>x.Items).Where(c=>c.Id==CartId && c.IsActive == true).FirstOrDefault();
        }

        public int DeleteItem(int cartId, int itemId)
        {
            var item = shopingContext.CartItems.Where(ci => ci.CartId == cartId && ci.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                shopingContext.CartItems.Remove(item);
                return shopingContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(int cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == itemId)
                    {
                        flag = true;
                        //for minus quantity
                        if (Quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.Items[i].Quantity += (Quantity);
                        break;
                    }
                }
                if (flag)
                    return shopingContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateCart(int cartId,Guid userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return shopingContext.SaveChanges();
        }

        public CartModel GetCartDetails(int CartId)
        {
            var model = (from cart in shopingContext.Carts
                         where cart.Id == CartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in shopingContext.CartItems
                                      join item in shopingContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == CartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = cartItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }
    }
}

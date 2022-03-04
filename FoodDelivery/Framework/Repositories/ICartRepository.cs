using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public  interface ICartRepository:IRepository<Cart,int,ShopingContext>
    {
        //Cart GetCart(int CartId);
        Cart GetCart(int CartId);
        CartModel GetCartDetails(int CartId);
        int DeleteItem(int cartId, int itemId);
        int UpdateQuantity(int cartId, int itemId, int Quantity);
        int UpdateCart(int cartId, Guid userId);
    }
}

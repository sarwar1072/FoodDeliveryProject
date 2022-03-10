using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public  interface ICartRepository:IRepository<Cart,Guid,ShopingContext>
    {
        //Cart GetCart(int CartId);
        Cart GetCart(Guid CartId);
        CartModel GetCartDetails(Guid CartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartId, Guid userId);
    }
}

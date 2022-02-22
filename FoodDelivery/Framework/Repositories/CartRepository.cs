using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class CartRepository:Repository<Cart,int ,ShopingContext>,ICartRepository
    {
        
        public CartRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }

        //public Cart GetCart(int CartId)
        //{
        //    return shopingContext.Carts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        //}
    }
}

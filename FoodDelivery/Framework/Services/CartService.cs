using Framework.Entities;
using Framework.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public class CartService:ICartService
    {
        private readonly IShoppingUnitOfWork _shopingUnitOfWork;
        public CartService(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shopingUnitOfWork = shopingUnitOfWork;
        }
        //public Cart GetCart(int CartId)
        //{

        //    return _shopingUnitOfWork.CartRepository.Get(c=>c.Id==CartId && c.IsActive==true,"Items");
        //        //Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        //}
    }
}

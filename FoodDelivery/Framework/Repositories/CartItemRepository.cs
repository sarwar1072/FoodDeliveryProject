using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class CartItemRepository: Repository<CartItem,int,ShopingContext>, ICartItemRepository
    {
        public CartItemRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
    }
}

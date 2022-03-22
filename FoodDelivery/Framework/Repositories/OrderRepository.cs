using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class OrderRepository:Repository<Order,string,ShopingContext>,IOrderRepository
    {
        public OrderRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
    }
}

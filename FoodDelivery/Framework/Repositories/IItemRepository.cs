using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public  interface IItemRepository:IRepository<Item,int,ShopingContext>
    {
    }
}

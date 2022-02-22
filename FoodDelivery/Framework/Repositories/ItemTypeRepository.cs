using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
    public class ItemTypeRepository:Repository<ItemType, int, ShopingContext>, IItemTypeRepository
    {

        public ItemTypeRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
          
    }
}

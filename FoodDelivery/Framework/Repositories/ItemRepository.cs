using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
    public class ItemRepository: Repository<Item, int, ShopingContext>, IItemRepository
    {
        public ItemRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
    }
}

using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class CategoryRepository: Repository<Category,int,ShopingContext>, ICategoryRepository
    {
        public CategoryRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }
    }
}

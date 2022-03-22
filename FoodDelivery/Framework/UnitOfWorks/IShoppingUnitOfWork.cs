using DataAccessLayer;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.UnitOfworks
{
    public interface IShoppingUnitOfWork : IUnitOfWork
    {
        //IProductRepository ProductRepositroy { get; set; }
        //ICategoryRepository CategoryRepository { get; set; }
        ICartRepository CartRepository { get; set; }

        ICategoryRepository CategoryRepository { get; set; }
        IItemRepository ItemRepository { get; set; }
        IItemTypeRepository ItemTypeRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        ICartItemRepository CartItemRepository { get; set; }

         IPaymentDetailsRepository PaymentDetailsRepository { get; set; }


    }
}

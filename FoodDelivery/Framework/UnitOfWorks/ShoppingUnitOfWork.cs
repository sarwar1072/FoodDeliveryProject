using DataAccessLayer;
using Framework.Contexts;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.UnitOfworks
{
    public class ShoppingUnitOfWork : UnitOfWork, IShoppingUnitOfWork
    {
       public ICartRepository CartRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IItemRepository ItemRepository { get; set; }
        public  IItemTypeRepository ItemTypeRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ShoppingUnitOfWork(ShopingContext context,
            ICartRepository cartRepository
            ,ICategoryRepository categoryRepository
            , IItemRepository itemRepository
            , IItemTypeRepository itemTypeRepository,
           IOrderRepository orderRepository )
            : base(context)
        {
            CartRepository = cartRepository;
            CategoryRepository = categoryRepository;
            ItemRepository = itemRepository;
            ItemTypeRepository = itemTypeRepository;
            OrderRepository = orderRepository;
        }
    }
}

using Framework.Entities;
using Framework.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Services
{
   public  class CatalogueServices: ICatalogueServices
    {
        private readonly IShoppingUnitOfWork _shopingUnitOfWork;
        public CatalogueServices(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shopingUnitOfWork = shopingUnitOfWork;
        }

        public void AddItem(Item item)
        {
            _shopingUnitOfWork.ItemRepository.Add(item);
            _shopingUnitOfWork.Save();
        }

        public void DeleteItem(int id)
        {
            _shopingUnitOfWork.ItemRepository.Remove(id);
            _shopingUnitOfWork.Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _shopingUnitOfWork.CategoryRepository.GetAll();
        }

        public Item GetItem(int id)
        {
            return _shopingUnitOfWork.ItemRepository.GetById(id);
        }

        public IEnumerable<Item> GetItems()
        {
            //return _itemRepo.GetAll().OrderBy(item => item.CategoryId).ThenBy(item => item.ItemTypeId);
           return _shopingUnitOfWork.ItemRepository.GetAll().OrderBy(item =>item.CategoryId).ThenBy(item =>item.ItemTypeId);
        }

        public IEnumerable<ItemType> GetItemTypes()
        {
            return _shopingUnitOfWork.ItemTypeRepository.GetAll();
        }

        public void UpdateItem(Item item)
        {
            _shopingUnitOfWork.ItemRepository.Edit(item);
            _shopingUnitOfWork.Save();
        }
    }
}

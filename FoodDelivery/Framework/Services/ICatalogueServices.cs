using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public interface ICatalogueServices
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<ItemType> GetItemTypes();
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}

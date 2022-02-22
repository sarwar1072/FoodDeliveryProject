using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Framework.Entities
{
    public class CartItem : IEntity<int>
    {
        public CartItem()
        {
            // required by EF
        }
        public CartItem(int itemId, int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public Cart Cart { get; set; }
    }
}

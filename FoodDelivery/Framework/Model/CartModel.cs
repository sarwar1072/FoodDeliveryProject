using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Framework.Model
{
    public class CartModel
    {
        public CartModel()
        {
            Items = new List<ItemModel>();
        }
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<ItemModel> Items { get; set; }
    }
}

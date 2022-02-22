using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Framework.Entities
{
    public class Order : IEntity<int>
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string PaymentId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
    }
}

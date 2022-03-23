using Framework.Entities;
using Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public interface IOrderService
    {
        OrderModel GetOrderDetails(string OrderId);
        IEnumerable<Order> GetUserOrders(Guid UserId);
        int PlaceOrder(Guid userId, string orderId, string paymentId, CartModel cart, Address address);
        PagingListModel<OrderModel> GetOrderList(int page = 1, int pageSize = 10);
    }
}

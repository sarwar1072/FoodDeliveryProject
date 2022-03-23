using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using Framework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
    public interface IOrderRepository: IRepository<Order,string,ShopingContext>
    {
        IEnumerable<Order> GetUserOrders(Guid UserId);
        OrderModel GetOrderDetails(string id);
        PagingListModel<OrderModel> GetOrderList(int page, int pageSize);

    }
}

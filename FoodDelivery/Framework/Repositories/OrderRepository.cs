using DataAccessLayer;
using Framework.Contexts;
using Framework.Entities;
using Framework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;

namespace Framework.Repositories
{
   public class OrderRepository:Repository<Order,string,ShopingContext>,IOrderRepository
    {
        public OrderRepository(ShopingContext shopingContext):base(shopingContext)
        {

        }

        public IEnumerable<Order> GetUserOrders(Guid UserId)
        {
            return _dbContext.Orders
               .Include(o => o.OrderItems)
               .Where(x => x.UserId == UserId).ToList();
        }

        public OrderModel GetOrderDetails(string orderId)
        {
            var model = (from order in _dbContext.Orders
                         where order.Id == orderId
                         select new OrderModel
                         {
                             Id = order.Id,
                             UserId = order.UserId,
                             CreatedDate = order.CreatedDate,
                             Items = (from orderItem in _dbContext.OrderItems
                                      join item in _dbContext.Items
                                      on orderItem.ItemId equals item.Id
                                      where orderItem.OrderId == orderId
                                      select new ItemModel
                                      {
                                          Id = orderItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = orderItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = orderItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }

        public PagingListModel<OrderModel> GetOrderList(int page, int pageSize)
        {
            var pagingModel = new PagingListModel<OrderModel>();
            var data = (from order in _dbContext.Orders
                        join payment in _dbContext.PaymentDetails
                        on order.PaymentId equals payment.Id
                        select new OrderModel
                        {
                            Id = order.Id,
                            UserId = order.UserId,
                            PaymentId = payment.Id,
                            CreatedDate = order.CreatedDate,
                            GrandTotal = payment.GrandTotal,
                            Locality = order.Locality
                        });
            int itemCounts = data.Count();
            var orders = data.Skip((page - 1) * pageSize).Take(pageSize);
            var pagedListData = new StaticPagedList<OrderModel>(orders, page, pageSize, itemCounts);
            pagingModel.Data = pagedListData;
            pagingModel.Page = page;
            pagingModel.PageSize = pageSize;
            pagingModel.TotalRows = itemCounts;
            return pagingModel;
        }

    }
}

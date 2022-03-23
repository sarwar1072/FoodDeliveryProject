using Framework.Entities;
using Framework.Model;
using Framework.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public class OrderService: IOrderService
    {
        private readonly IShoppingUnitOfWork _shopingUnitOfWork;

        public OrderService(IShoppingUnitOfWork shopingUnitOfWork)
        {
            _shopingUnitOfWork = shopingUnitOfWork;
        }

        public OrderModel GetOrderDetails(string OrderId)
        {
            var model = _shopingUnitOfWork.OrderRepository.GetOrderDetails(OrderId);
            if (model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach (var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //5% tax
                model.Tax = Math.Round((model.Total * 5) / 100, 2);
                model.GrandTotal = model.Tax + model.Total;
            }
            return model;
        }

        public PagingListModel<OrderModel> GetOrderList(int page = 1, int pageSize = 10)
        {
            return _shopingUnitOfWork.OrderRepository.GetOrderList(page, pageSize);
        }

        public IEnumerable<Order> GetUserOrders(Guid UserId)
        {
            return _shopingUnitOfWork.OrderRepository.GetUserOrders(UserId);
        }

        public int PlaceOrder(Guid userId, string orderId, string paymentId, CartModel cart, Address address)
        {
            Order order = new Order
            {
                PaymentId = paymentId,
                UserId = userId,

                CreatedDate = DateTime.Now,
                Id = orderId,
                Street = address.Street,
                Locality = address.Locality,
                City = address.City,
                ZipCode = address.ZipCode,
                PhoneNumber = address.PhoneNumber
            };
            foreach (var item in cart.Items)
            {
                OrderItem orderItem = new OrderItem(item.ItemId, item.UnitPrice, item.Quantity, item.Total);
                order.OrderItems.Add(orderItem);
            }
            _shopingUnitOfWork.OrderRepository.Add(order);
            return _shopingUnitOfWork.SaveChanges();
        }


    }
}

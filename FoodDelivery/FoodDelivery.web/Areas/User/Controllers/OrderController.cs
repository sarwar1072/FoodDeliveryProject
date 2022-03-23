using FoodDelivery.web.Models;
using Framework.Model;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.User.Controllers
{
    public class OrderController : BaseController
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService, IUserAccessor userAccessor): base(userAccessor)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetUserOrders(CurrentUser.Id);
            return View(orders);
        }

        [Route("~/User/Order/Details/{OrderId}")]
        public IActionResult Details(string OrderId)
        {
            OrderModel Order = _orderService.GetOrderDetails(OrderId);
            return View(Order);
        }
    }
}

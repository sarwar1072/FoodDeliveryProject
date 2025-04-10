﻿using Framework.Model;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        IOrderService _orderService;
        public DashboardController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index(int page = 1, int pageSize = 4)
        {
            var orders = _orderService.GetOrderList(page, pageSize);
            return View(orders);
        }
        [Route("~/Admin/Dashboard/Details/{OrderId}")]
        public IActionResult Details(string OrderId)
        {
            OrderModel Order = _orderService.GetOrderDetails(OrderId);
            return View(Order);
        }
    }
}

using FoodDelivery.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {

        public DashboardController(IUserAccessor userAccessor) : base(userAccessor)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

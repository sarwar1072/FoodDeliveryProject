using FoodDelivery.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

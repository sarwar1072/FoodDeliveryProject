using FoodDelivery.web.Models;
using Membership.Entities;
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

        public ApplicationUser CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;
            }
        }

        IUserAccessor _userAccessor;
        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

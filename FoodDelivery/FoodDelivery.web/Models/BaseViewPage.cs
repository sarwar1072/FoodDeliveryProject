using Membership.Entities;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        [RazorInject]
        public IUserAccessor _userAccessor { get; set; }
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
    }
}

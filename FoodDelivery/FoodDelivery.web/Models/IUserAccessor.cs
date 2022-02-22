
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public interface IUserAccessor
    {
        ApplicationUser GetUser();
    }
}

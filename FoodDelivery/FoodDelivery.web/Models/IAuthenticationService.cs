using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public interface IAuthenticationService
    {
        bool CreateUser(ApplicationUser user, string Password);
        Task<bool> SignOut();
        ApplicationUser AuthenticateUser(string Username, string Password);
        ApplicationUser GetUser(string Username);
    }
}

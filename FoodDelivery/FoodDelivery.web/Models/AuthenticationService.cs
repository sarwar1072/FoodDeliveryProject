using Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<ApplicationUser> _signManager;
        protected UserManager<ApplicationUser> _userManager;
        protected RoleManager<Role> _roleManager;
        public AuthenticationService(SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
        }
        public ApplicationUser AuthenticateUser(string Username, string Password)
        {
            var result =_signManager.PasswordSignInAsync(Username,Password,false,lockoutOnFailure: false).Result;
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(Username).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public bool CreateUser(ApplicationUser user, string Password)
        {
            var result = _userManager.CreateAsync(user, Password).Result;
            if (result.Succeeded)
            {
                //Admin, User
                //string role = "Admin";

                string role = "Admin";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public ApplicationUser GetUser(string Username)
        {
            return _userManager.FindByNameAsync(Username).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

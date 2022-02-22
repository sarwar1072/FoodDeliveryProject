using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        [NotMapped]
        public string[] Roles { get; set; }
        public ApplicationUser()
                    : base()
        {

        }

        internal ApplicationUser(string userName)
            : base(userName)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Compare Password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

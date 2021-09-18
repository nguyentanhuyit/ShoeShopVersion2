using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Shoe.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        [Remote(action: "VerifyUsername", controller:"Account")]
        public string Username { get; set; }

        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Remote(action: "VerifyEmail", controller: "Account")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Verified { get; set; }
        public DateTime Birthday { get; set; }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string UrlImage { get; set; }
        public string ActivationCode { get; set; }
        public string ResetPassCode { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    public enum Gender
    {
        Nam, Nữ, Khác
    }
}

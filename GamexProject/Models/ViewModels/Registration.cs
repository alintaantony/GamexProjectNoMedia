using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamexProject.Models.ViewModels
{
    public class Registration
    {
        [Required(ErrorMessage = "Please Enter the Username(No spaces or special characters allowed)")]
        [DisplayName("Username")]
        [RegularExpression("^[A-Za-z0-9]*$", ErrorMessage = "Username cannot contain any spaces or special characters !!")]
        [Remote("IsUserNameAvailable", "RegisterUser", ErrorMessage = "Username already exits ! Please Choose Another Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Your Full Name")]
        [DisplayName("Full Name")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name can only contain alphabets !!")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage ="Please Enter the Password")]
        [DisplayName("Password(Minimum 4 characters)")]
        [MinLength(4, ErrorMessage = "Password must contain atleast 4 characters")]
        public string UserPassword { get; set; }

        [DisplayName("Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword", ErrorMessage = "Passwords Do not Match !! Please Try Again")]
        public string CofirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter a Wallet Amount")]
        [DisplayName("Wallet Amount")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        public Nullable<double> Wallet { get; set; }
    }
}
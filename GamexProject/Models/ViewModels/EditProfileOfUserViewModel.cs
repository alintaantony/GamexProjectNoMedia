using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamexProject.Models.ViewModels
{
    public class EditProfileOfUserViewModel
    {

        [Required(ErrorMessage = "Please Enter the New Name")]
        [DisplayName("Edit Name")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Name can only contain alphabets !!")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Please Enter the new Email")]
        [DisplayName("Edit Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Your Old Password")]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please Enter the new Password")]
        [DisplayName("New Password(Minimum 4 characters)")]
        [MinLength(4, ErrorMessage = "Password must contain atleast 4 characters")]
        public string UserPassword { get; set; }

        [DisplayName("Confirm New Password")]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword", ErrorMessage = "Passwords Do not Match !! Please Try Again")]
        public string CofirmPassword { get; set; }
    }
}
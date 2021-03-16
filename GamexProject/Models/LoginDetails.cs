using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamexProject.Models
{
    public class LoginDetails
    {
        [Key]
        [Required(ErrorMessage ="Please Enter the Username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Please Enter the Password")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamexProject.Models.ViewModels
{
    public class RechargeWalletViewModel
    {
        [Required(ErrorMessage = "Please Enter a Wallet Amount")]
        [DisplayName("Wallet Amount")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        public Nullable<double> Wallet { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamexProject.Models.ViewModels
{
    public class SellGameViewModel
    {
        [Required(ErrorMessage = "Please Enter the Game ID")]
        [DisplayName("Game ID")]
        public string GameId { get; set; }
    }
}
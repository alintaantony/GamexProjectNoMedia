//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamexProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class GameDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GameDetail()
        {
            this.DlcDetails = new HashSet<DlcDetail>();
            this.PurchasedGameDetails = new HashSet<PurchasedGameDetail>();
        }

        [Required(ErrorMessage = "Please Enter the Game ID")]
        [DisplayName("Game ID")]
        public string GameId { get; set; }
        [Required(ErrorMessage = "Please Enter the Game Name")]
        [DisplayName("Game Name")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Please Enter the Game Genre")]
        [DisplayName("Game Genre")]
        public string GameGenre { get; set; }

        [Required(ErrorMessage = "Please Enter the Game Price")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        [DisplayName("Game Price")]
        public Nullable<double> GamePrice { get; set; }

        [Required(ErrorMessage = "Please Enter the Game Resale Value")]
        [DisplayName("Game Resale Value")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        public Nullable<double> GameResaleValue { get; set; }

        [DisplayName("Number Of Units Sold")]
        public Nullable<int> GamePurchaseCount { get; set; }

        [Required(ErrorMessage = "Please Enter the Game Description")]
        [DisplayName("Game Description")]
        public string GameDescription { get; set; }


        [DisplayName("Upload Image")]
        public string GameImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DlcDetail> DlcDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasedGameDetail> PurchasedGameDetails { get; set; }
    }
}

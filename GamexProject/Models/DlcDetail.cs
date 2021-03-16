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

    public partial class DlcDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DlcDetail()
        {
            this.PurchasedDlcDetails = new HashSet<PurchasedDlcDetail>();
        }

        [Required(ErrorMessage = "Please Enter the DLC ID")]
        [DisplayName("DLC ID")]
        public string DlcId { get; set; }

        [Required(ErrorMessage = "Please Enter the DLC Name")]
        [DisplayName("DLC Name")]
        public string DlcName { get; set; }

        [Required(ErrorMessage = "Please Enter the DLC Price")]
        [DisplayName("DLC Price")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        public Nullable<double> DlcPrice { get; set; }

        [Required(ErrorMessage = "Please Enter the DLC Resale Value")]
        [DisplayName("DLC Resale Value")]
        [RegularExpression("^[0-9]+[0-9]*$", ErrorMessage = "Please enter a value equal to or greater than zero")]
        public Nullable<double> DlcResaleValue { get; set; }

        [DisplayName("Number of Units Sold")]
        public Nullable<int> DlcPurchaseCount { get; set; }

        [Required(ErrorMessage = "Please Enter the Game ID")]
        [DisplayName("DLC's Game ID")]
        public string GameId { get; set; }
    
        public virtual GameDetail GameDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasedDlcDetail> PurchasedDlcDetails { get; set; }
    }
}

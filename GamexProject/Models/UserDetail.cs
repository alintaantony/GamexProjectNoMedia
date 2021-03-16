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
    using System.Web.Mvc;

    public partial class UserDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetail()
        {
            this.PurchasedDlcDetails = new HashSet<PurchasedDlcDetail>();
            this.PurchasedGameDetails = new HashSet<PurchasedGameDetail>();
        }
        public UserDetail(string username,string userFullName, string userEmail, string userPassword,string userRole,double? wallet,int userThreatLevel,int userBanStatus)
        {
            Username = username;
            UserFullName = userFullName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserRole = userRole;
            Wallet = wallet;
            UserThreatLevel = userThreatLevel;
            UserBanStatus = userBanStatus;
        }
        public string Username { get; set; }

        public string UserFullName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string UserRole { get; set; }

        public Nullable<double> Wallet { get; set; }
        public Nullable<int> UserThreatLevel { get; set; }
        public Nullable<int> UserBanStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasedDlcDetail> PurchasedDlcDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchasedGameDetail> PurchasedGameDetails { get; set; }
    }
}

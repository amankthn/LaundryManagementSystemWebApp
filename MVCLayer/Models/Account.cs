using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCLayer.CustomValidation;
namespace MVCLayer.Models
{
    public class Account
    {
        public int AccID { get; set; }
        [Required]
        [CustomAccStatus(ErrorMessage = "Account Status must be one of the following : Active or Inactive")]
        public string AccStatus { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public decimal Pending { get; set; }

        public int CustID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
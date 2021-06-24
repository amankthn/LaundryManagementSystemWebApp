using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCLayer.Models
{
    public class ChnageAddressModel
    {
        [Required]
        [MaxLength(500, ErrorMessage = "Adress Too Long. Please enter less than 500 charaters.")]
        public string Address { get; set; }
    }
}
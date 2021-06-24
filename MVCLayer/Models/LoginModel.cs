using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCLayer.Models
{
    public class LoginModel { 
    
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string grant_type { get; set; }
    }
}
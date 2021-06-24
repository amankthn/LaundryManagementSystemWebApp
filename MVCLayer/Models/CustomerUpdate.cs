using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCLayer.CustomValidation;
namespace MVCLayer.Models
{
    public class CustomerUpdate
    {
        public CustomerUpdate()
        {
            this.Accounts = new HashSet<Account>();
            this.Orders = new HashSet<Order>();
        }

        public int CustID { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "First Name Should Be less than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "First Name Should Be less than 100 characters")]
        public string LastName { get; set; }
        [Required]
        [Range(18, 80, ErrorMessage = "Only people aged 18 to 80 allowed")]
        public int Age { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Enter 10 Digit Phone Number")]
        [MaxLength(10, ErrorMessage = "Enter 10 Digit Phone Number")]
        [Phone]
        public string PhoneNo { get; set; }
        [Required]
        public string CAddress { get; set; }
        [Required]
        [CustomGender(ErrorMessage = "Enter M for Male, F for Female")]
        public string Gender { get; set; }
       
        public string Username { get; set; }
       
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

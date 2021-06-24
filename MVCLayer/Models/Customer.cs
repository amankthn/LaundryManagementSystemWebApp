using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLayer.CustomValidation;
using System.ComponentModel.DataAnnotations;
namespace MVCLayer.Models
{
    public class Customer
    {
        public Customer()
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
        [MaxLength(500, ErrorMessage = "Adress Too Long. Please enter less than 500 charaters.")]
        public string CAddress { get; set; }
        [Required]
        [CustomGender(ErrorMessage = "Enter M for Male, F for Female")]
        public string Gender { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password Should be 8 to 16 characters long")]
        [MaxLength(16, ErrorMessage = "Password Should be 8 to 16 characters long")]
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
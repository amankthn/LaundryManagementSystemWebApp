using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Accounts = new HashSet<Account>();
            this.Orders = new HashSet<Order>();
        }

        public int CustID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }
        public string CAddress { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
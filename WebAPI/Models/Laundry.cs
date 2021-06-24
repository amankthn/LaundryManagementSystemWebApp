using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Laundry
    {
        public Laundry()
        {
            this.Orders = new HashSet<Order>();
        }

        public int laundryID { get; set; }
        public string type { get; set; }
        public decimal CostPerUnit { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
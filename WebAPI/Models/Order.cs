using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string OrderStatus { get; set; }
        public int laundryID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Laundry Laundry { get; set; }
    }
}
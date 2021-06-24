using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace MVCLayer.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string OrderStatus { get; set; }
        [Required]
        public int laundryID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }

        public virtual Customer Customer { get; set; }
        
        public virtual Laundry Laundry { get; set; }
    }
}
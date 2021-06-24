using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Account
    {
        public int AccID { get; set; }
        public string AccStatus { get; set; }
        public decimal Cost { get; set; }
        public decimal Pending { get; set; }
        public int CustID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCLayer.CustomValidation
{
    public class CustomAccStatus : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string accStatus = Convert.ToString(value);
            if (accStatus == "Active" || accStatus == "Inactive")
                return true;
            return false;
        }
    }
}
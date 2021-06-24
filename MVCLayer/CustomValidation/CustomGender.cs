using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCLayer.CustomValidation
{
    public class CustomGender : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string accStatus = Convert.ToString(value);
            if (accStatus == "M" || accStatus == "F")
                return true;
            return false;
        }
    }
}
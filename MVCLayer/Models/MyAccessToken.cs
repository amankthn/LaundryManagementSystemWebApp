using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLayer.Models
{
    public class MyAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

    }
}
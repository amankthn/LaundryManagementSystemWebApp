using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace WebAPI.Controllers
{
    public class LaundryController : ApiController
    {
        public List<Laundry> GetLaundries()
        {
            LaundryDBHelper customerDBHelper = new LaundryDBHelper();
            return customerDBHelper.GetLaundries().ToList();
        }
    }
}

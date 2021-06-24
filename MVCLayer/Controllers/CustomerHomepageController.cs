using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class CustomerHomepageController : Controller
    {
        // GET: CustomerHomepage
        public ActionResult Index()
        {
            return View();
        }
    }
}
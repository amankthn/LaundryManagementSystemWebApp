using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLayer.Controllers
{
    public class ErrorController : Controller
    {
        // GET: NotFound
        
        public ActionResult NotFound()
        {
            ViewBag.error = "The page you're looking for was not found.";
            return View();
        }

        public ActionResult Unauthorized()
        {
            ViewBag.error = "You are not authorized to view this page.";
            return View();
        }
    }
}
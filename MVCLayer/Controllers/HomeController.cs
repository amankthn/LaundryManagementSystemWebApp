using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using MVCLayer.Models;
using BusinessLayer;
using Newtonsoft.Json;
namespace MVCLayer.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            CustomerBL customerBL = new CustomerBL();
            string customers = await customerBL.GetCustomerCount();
            ViewBag.Count = customers;
            Session["customercount"] = customers;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Laundry Management System - Team 8.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us At.";

            return View();
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Threading.Tasks;
namespace MVCLayer.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<ActionResult> Home()
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                CustomerBL customerBL = new CustomerBL();
                string customers = await customerBL.GetCustomerCount();
                ViewBag.customercount = customers;
                OrderBL orderBL = new OrderBL();
                string orders = await orderBL.GetOrderCount(Session["token"].ToString());
                ViewBag.ordercount = orders;
                Session["customercount"] = customers;
                Session["ordercount"] = orders;
                return View();
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
    }
}
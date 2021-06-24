using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Threading.Tasks;
using MVCLayer.Models;
using Newtonsoft.Json;
namespace MVCLayer.Controllers
{
    public class LaundryController : Controller
    {
        // GET: Laundry
        public async Task<ActionResult> Index()
        {
            LaundryBL laundryBL = new LaundryBL();
            string laundries = await laundryBL.GetLaundries();
            List<Laundry> laundryList = JsonConvert.DeserializeObject<List<Laundry>>(laundries);
            return View(laundryList);
        }


        //public async Task<ActionResult> Login(Customer cust)
        //{
        //    string custJson = JsonConvert.SerializeObject(cust);
        //    LaundryBL laundryBL = new LaundryBL();
        //    laundryBL.Login(custJson);
        //    return View();
        //}
    }
}
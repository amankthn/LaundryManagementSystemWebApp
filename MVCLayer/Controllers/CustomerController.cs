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
    public class CustomerController : Controller
    {
        // GET: Customer
        
        
        public async Task<ActionResult> Index()
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                CustomerBL customerBL = new CustomerBL();
                string customers = await customerBL.GetCustomers(Session["token"].ToString());
                List<Customer> cust = JsonConvert.DeserializeObject<List<Customer>>(customers);
                return View(cust);
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            CustomerBL customerBL = new CustomerBL();
            string customers = await customerBL.GetCustomers(Session["token"].ToString());
            List<Customer> cust = JsonConvert.DeserializeObject<List<Customer>>(customers);
            Session["custId"] = id;
            Customer myC = cust.Find(c => c.CustID == id);
            CustomerUpdate myCu = new CustomerUpdate();
            myCu.FirstName = myC.FirstName;
            myCu.LastName = myC.LastName;
            myCu.Age = myC.Age;
            myCu.Gender = myC.Gender;
            myCu.CAddress = myC.CAddress;
            myCu.PhoneNo = myC.PhoneNo;
            myCu.Username = myC.Username;
            return View(myCu);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CustomerUpdate c)
        {

            if (ModelState.IsValid)
            {
                if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
                {
                    c.CustID = (int)Session["custId"];
                    CustomerBL customerBL = new CustomerBL();
                    string customer = JsonConvert.SerializeObject(c);
                    string result = await customerBL.EditC(customer, Session["token"].ToString());
                    string customers = await customerBL.GetCustomers(Session["token"].ToString());
                    c.Username = "temp";
                    List<Customer> cust = JsonConvert.DeserializeObject<List<Customer>>(customers);
                    return View("Index", cust);

                }
                else
                {
                    return RedirectToAction("Unauthorized", "Error");
                }
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer c)
        {

            if (ModelState.IsValid)
            {

                
                CustomerBL customerBL = new CustomerBL();
                string customer = JsonConvert.SerializeObject(c);
                string result = await customerBL.RegisterCustomer(customer);
                if (result.Length > 10)
                {
                    ViewBag.error = result.Substring(1, result.Length - 2);
                    return View("Create");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Create");
            }
        }

        public async Task<ActionResult> EditAddress()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> EditAddress(ChnageAddressModel c)
        {

            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"user\"")
            {

                if (ModelState.IsValid)
                {
                    CustomerBL customerBL = new CustomerBL();
                    Customer cust = new Customer();
                    cust.Username = Session["username"].ToString();
                    cust.CAddress = c.Address;
                    string cs = JsonConvert.SerializeObject(cust);
                    string result = await customerBL.ChangeAddress(cs, Session["token"].ToString());
                    return RedirectToAction("Index", "Home");
                }
                return View("EditAddress");
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
    }
}
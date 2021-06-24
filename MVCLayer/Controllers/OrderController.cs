using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MVCLayer.Models;
using BusinessLayer;
using Newtonsoft.Json;
namespace MVCLayer.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public async Task<ActionResult> Index()
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                OrderBL orderBL = new OrderBL();
                string orders = await orderBL.GetOrders(Session["token"].ToString());
                List<Order> ord = JsonConvert.DeserializeObject<List<Order>>(orders);
                return View(ord);
            }
            return RedirectToAction("Unauthorized", "Error");
        }

        public async Task<ActionResult> UpdateStatus(int id)
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                OrderBL orderBL = new OrderBL();
                string updated = await orderBL.UpdateStatus(id, Session["token"].ToString());
                string orders = await orderBL.GetOrders(Session["token"].ToString());
                List<Order> ord = JsonConvert.DeserializeObject<List<Order>>(orders);
                return View("Index", ord);
            }
            return RedirectToAction("Unauthorized", "Error");
        }

        public async Task<ActionResult> GenerateInvoice(int id)
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                OrderBL orderBL = new OrderBL();
                string updated = await orderBL.GenerateInvoice(id, Session["token"].ToString());
                string orders = await orderBL.GetOrders(Session["token"].ToString());
                List<Order> ord = JsonConvert.DeserializeObject<List<Order>>(orders);
                return View(ord.Find(o => o.OrderID == id));
            }
            return RedirectToAction("Unauthorized", "Error");
        }

        public async Task<ActionResult> TrackOrder()
        {
            if (Session["loggedIn"] != null)
            {
                OrderBL orderBL = new OrderBL();
                string orders = await orderBL.TrackOrder(Session["username"].ToString(), Session["token"].ToString());
                List<Order> ord = JsonConvert.DeserializeObject<List<Order>>(orders);
                return View(ord);
            }
            return RedirectToAction("Unauthorized", "Error");
        }

        public async Task<ActionResult> Create()
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"user\"")
            {
                LaundryBL laundryBL = new LaundryBL();
                string laundriesString = await laundryBL.GetLaundries();
                List<Laundry> laundries = JsonConvert.DeserializeObject<List<Laundry>>(laundriesString);
                Session["laundries"] = laundries;
                return View();
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order o)
        {

            if (ModelState.IsValid)
            {
                if (Session["loggedIn"] != null && Session["role"].ToString() == "\"user\"")
                {

                    CustomerBL customerBL = new CustomerBL();
                    string customerString = await customerBL.GetCustomerByUsername(Session["username"].ToString(), Session["token"].ToString());
                    Customer customer = JsonConvert.DeserializeObject<Customer>(customerString);
                    o.CustID = customer.CustID;
                    LaundryBL laundryBL = new LaundryBL();
                    string laundriesString = await laundryBL.GetLaundries();
                    List<Laundry> laundries = JsonConvert.DeserializeObject<List<Laundry>>(laundriesString);
                    o.Amount = o.Quantity * laundries.Find(l => l.laundryID == o.laundryID).CostPerUnit;
                    //o.Laundry = laundries.Find(l => l.laundryID == o.laundryID);
                    o.OrderStatus = "Pending";
                    o.OrderDate = DateTime.Now;
                    OrderBL orderBL = new OrderBL();
                    string order = JsonConvert.SerializeObject(o);
                    string response = await orderBL.SendClothes(order, Session["token"].ToString());
                    Session["laundries"] = laundries;
                    return View("OrderPlaced", o);
                }
                else
                {
                    return RedirectToAction("Unauthorized", "Error");
                }

            }
            else
            {
                return View("Create");
            }
        }

        public ActionResult OrderPlaced(Order o)
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"user\"")
            {
                return View(o);
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
    }
}
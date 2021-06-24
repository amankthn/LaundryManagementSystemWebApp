using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
namespace WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        [Authorize(Roles ="admin")]
        public List<Order> GetOrders()
        {
            OrderDBHelper orderDBHelper = new OrderDBHelper();
            return orderDBHelper.GetOrders().ToList().OrderByDescending(o => o.OrderDate).ToList();
        }
        [Authorize(Roles = "admin")]
        [Route("api/OrderCount")]
        public int GetOrderCount()
        {
            OrderDBHelper orderDBHelper = new OrderDBHelper();
            return orderDBHelper.GetOrderCount();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/UpdateOrder/{id}")]
        public bool UpdateOrder(int id)
        {
            OrderDBHelper orderDBHelper = new OrderDBHelper();
            return orderDBHelper.UpdateStatus(id);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/GenerateInvoice/{id}")]
        public bool GenerateInvoice(int id)
        {
            OrderDBHelper orderDBHelper = new OrderDBHelper();
            return orderDBHelper.GenerateInvoice(id);
        }

        [HttpGet]
        [Route("api/order/{username}")]
        [Authorize]
        public List<Order> TrackOrder(string username)
        {
            OrderDBHelper orderDBHelper = new OrderDBHelper();
            return orderDBHelper.GetOrders().ToList().FindAll(o => o.Customer.Username == username).OrderByDescending(o => o.OrderDate).ToList();
        }

        [Authorize(Roles ="user")]
        [HttpPost]
        public string SendClothes(Order o)
        {
            try
            {
                OrderDBHelper dBHelper = new OrderDBHelper();
                return dBHelper.SendColthes(o);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

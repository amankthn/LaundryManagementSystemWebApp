using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class OrderDBHelper
    {
        public DbSet<Order> GetOrders()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Orders;
        }
       
        public int GetOrderCount()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Orders.Count();
        }

        public bool UpdateStatus(int id)
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            Order myOrder = db.Orders.ToList().Find(order => order.OrderID == id);
            bool updated = false;
            if (myOrder.OrderStatus == "Ready")
            {
                myOrder.DeliveryDate = DateTime.Now;
                myOrder.OrderStatus = "Delivered";
                db.SaveChanges();
                updated = true;
            }
            else if (myOrder.OrderStatus == "Pending")
            {
                
                myOrder.OrderStatus = "Ready";
                db.SaveChanges();
                updated = true;
            }
            return updated;
        }

        public bool GenerateInvoice(int orderId)
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            db.GenerateInvoice(orderId);
            return true;
        }

        public string SendColthes(Order o)
        {
            try
            {
                LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
                db.Orders.Add(o);
                db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "false";
        }

    }
}

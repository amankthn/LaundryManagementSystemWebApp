using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ExceptionsLayer;
namespace DataLayer
{
    public class CustomerDBHelper
    {
        public DbSet<Customer> GetCustomers()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Customers;
        }

        public int GetCustomerCount()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Customers.Count();
        }

        public bool UpdateCustomer(Customer cu)
        {
            try
            {
                LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
                Customer cust = db.Customers.ToList().Find(c => c.CustID == cu.CustID);
                cust.FirstName = cu.FirstName;
                cust.LastName = cu.LastName;
                cust.Age = cu.Age;
                cust.CAddress = cu.CAddress;
                cust.Gender = cu.Gender;
                cust.PhoneNo = cu.PhoneNo;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }
        public string RegisterCustomer(Customer cu)
        {
            try
            {
                LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
                if (db.Customers.ToList().Find(c => c.Username == cu.Username) != null)
                {
                    throw new CustomerException("Username Not Available");
                }
                db.Customers.Add(cu);
                db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "false";
        }

        public bool ChangeAdderss(Customer cu)
        {
            try
            {
                LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
                Customer cust = db.Customers.ToList().Find(c => c.Username == cu.Username);

                cust.CAddress = cu.CAddress;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public Customer GetCustomerByUsername(string username)
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Customers.ToList().Find(c => c.Username == username);
        }
    }
}

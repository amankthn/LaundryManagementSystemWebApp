using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [Authorize(Roles = "admin")]
        public List<Customer> GetCustomers()
        {
            CustomerDBHelper customerDBHelper = new CustomerDBHelper();
            return customerDBHelper.GetCustomers().ToList();
        }
        [Route("api/CustomerCount")]
        public int GetCustomerCount()
        {
            CustomerDBHelper customerDBHelper = new CustomerDBHelper();
            return customerDBHelper.GetCustomerCount();
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public bool Edit(Customer c)
        {
            CustomerDBHelper dBHelper = new CustomerDBHelper();
            return dBHelper.UpdateCustomer(c);
        }

       
        [HttpPost]
        public string Register(Customer c)
        {
            try
            {
                CustomerDBHelper dBHelper = new CustomerDBHelper();
                return dBHelper.RegisterCustomer(c);
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        [Route("api/ChangeAddress")]
        public bool EditAddress(Customer customer)
        {
            CustomerDBHelper dBHelper = new CustomerDBHelper();
            return dBHelper.ChangeAdderss(customer);
        }

        [Authorize(Roles = "user")]
        [Route("api/Customer/{username}")]
        [HttpGet]
        public Customer GetCustomerByUsername(string username)
        {
            CustomerDBHelper customerDBHelper = new CustomerDBHelper();
            return customerDBHelper.GetCustomerByUsername(username);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Net.Http;
using System.Net.Http.Headers;
namespace BusinessLayer
{
    public class CustomerBL
    {
        public async Task<string> GetCustomers(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("customer");
                if (responseTask.IsSuccessStatusCode)
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    return response;
                }
                else
                {
                    //Error response received   
                    //customers = Enumerable.Empty<Customer>();
                    //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return null;
        }

        public async Task<string> GetCustomerCount()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                var responseTask = await client.GetAsync("customercount");
                if (responseTask.IsSuccessStatusCode)
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    return response;
                }
                else
                {
                    //Error response received   
                    //customers = Enumerable.Empty<Customer>();
                    //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return null;
        }

        public async Task<string> EditC(string customer, string accessToken)
        {
            string Baseurl = "https://localhost:44316/api/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PutAsync("Customer", new StringContent(customer, System.Text.UnicodeEncoding.UTF8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    var cust = res.Content.ReadAsStringAsync().Result;
                    return cust;
                }
                var cust1 = res.Content.ReadAsStringAsync().Result;
                return null;
            }
        }
        public async Task<string> RegisterCustomer(string customer)
        {
            string Baseurl = "https://localhost:44316/api/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PostAsync("Customer", new StringContent(customer, System.Text.UnicodeEncoding.UTF8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    var cust = res.Content.ReadAsStringAsync().Result;
                    return cust;
                }
                var cust1 = res.Content.ReadAsStringAsync().Result;
                return cust1;
            }
        }

        public async Task<string> ChangeAddress(string c, string accessToken)
        {

            string Baseurl = "https://localhost:44316/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //   var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                //    HttpResponseMessage Res = await client.PostAsync("api/Account" + id, stringContent);
                HttpResponseMessage Res = await client.PostAsync("api/ChangeAddress", new StringContent(c, System.Text.UnicodeEncoding.UTF8, "application/json"));
                if (Res.IsSuccessStatusCode)
                {
                    var custres = Res.Content.ReadAsStringAsync().Result;
                    return custres;
                }
                return null;
            }


        }
        public async Task<string> GetCustomerByUsername(string username, string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("customer/" + username);
                if (responseTask.IsSuccessStatusCode)
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    return response;
                }
                else
                {
                    //Error response received   
                    //customers = Enumerable.Empty<Customer>();
                    //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return null;
        }
    }
}

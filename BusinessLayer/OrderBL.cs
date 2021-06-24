using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace BusinessLayer
{
    public class OrderBL
    {
        public async Task<string> GetOrders(string accessToken)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = await client.GetAsync("order");




                //If success received   
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
        public async Task<string> GetOrderCount(string accessToken)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("ordercount");
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


        public async Task<string> UpdateStatus(int id, string accessToken)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("updateorder/" + id);
                if (responseTask.IsSuccessStatusCode)
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    return response;
                }
                else
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    //Error response received   
                    //customers = Enumerable.Empty<Customer>();
                    //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return null;
        }

        public async Task<string> GenerateInvoice(int id, string accessToken)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("generateinvoice/" + id);
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
        public async Task<string> TrackOrder(string username,string accessToken)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = await client.GetAsync("order/" + username);
                //If success received   
                if (responseTask.IsSuccessStatusCode)
                {
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    return response;
                }
                else
                {
                    //Error response received   
                    //customers = Enumerable.Empty<Customer>();
                    var response = responseTask.Content.ReadAsStringAsync().Result;
                    //ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return null;
        }


        public async Task<string> SendClothes(string order, string accessToken)
        {
            string Baseurl = "https://localhost:44316/api/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.PostAsync("Order", new StringContent(order, System.Text.UnicodeEncoding.UTF8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    var cust = res.Content.ReadAsStringAsync().Result;
                    return cust;
                }
                var cust1 = res.Content.ReadAsStringAsync().Result;
                return cust1;
            }
        }
    }
}

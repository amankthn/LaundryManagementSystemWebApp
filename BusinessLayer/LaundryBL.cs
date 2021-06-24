using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Net.Http;
namespace BusinessLayer
{
    public class LaundryBL
    {
        public async Task<string> GetLaundries()
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = await client.GetAsync("laundry");




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
    }
}

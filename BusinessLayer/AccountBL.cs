using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLayer
{
    public class AccountBL
    {
        public async Task<string> GetAccounts(string accessToken)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var responseTask = await client.GetAsync("account");




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


        public async Task<string> EditC(string c, int id, string accessToken)
        {

            string Baseurl = "https://localhost:44316/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Account", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var account = Res.Content.ReadAsStringAsync().Result;
                    return account;
                }
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ExceptionsLayer;
namespace BusinessLayer
{
    public class LoginBL
    {
        public async Task<string> Login(string userInfo)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                UserLoginBL userLogin = JsonConvert.DeserializeObject<UserLoginBL>(userInfo);
                KeyValuePair<string, string> username = new KeyValuePair<string, string>("username", userLogin.username);
                KeyValuePair<string, string> password = new KeyValuePair<string, string>("password", userLogin.password);
                KeyValuePair<string, string> granttype = new KeyValuePair<string, string>("grant_type", userLogin.grant_type);
                List<KeyValuePair<string, string>> mykey = new List<KeyValuePair<string, string>>();
                mykey.Add(username);
                mykey.Add(password);
                mykey.Add(granttype);
                var formContent = new FormUrlEncodedContent(mykey);
                HttpResponseMessage Res = await client.PostAsync("token", formContent);
                //If success received   
                if (Res.IsSuccessStatusCode)
                {
                    var tokenResponse = Res.Content.ReadAsStringAsync().Result;
                    return tokenResponse;
                }
                else
                {
                    throw new LoginException(Res.Content.ReadAsStringAsync().Result);
                }
            }
            return null;
        }



        public async Task<string> GetRole(string accessToken)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/data/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage Res = await client.GetAsync("authenticate");
                //If success received   
                if (Res.IsSuccessStatusCode)
                {
                    var tokenResponse = Res.Content.ReadAsStringAsync().Result;
                    return tokenResponse;
                }
                else
                {
                    throw new LoginException(Res.Content.ReadAsStringAsync().Result);
                }
            }
            return null;
        }
    }
}

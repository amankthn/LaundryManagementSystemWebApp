using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLayer.Models;
using BusinessLayer;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ExceptionsLayer;
namespace MVCLayer.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            
            this.Session["token"] = "i was called";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    LoginBL loginBL = new LoginBL();
                    loginModel.grant_type = "password";
                    string request = JsonConvert.SerializeObject(loginModel);
                    string token = await loginBL.Login(request);
                    MyAccessToken myToken = JsonConvert.DeserializeObject<MyAccessToken>(token);
                    string role = await loginBL.GetRole(myToken.access_token);
                    Session["token"] = myToken.access_token;
                    Session["loggedIn"] = "true";
                    Session["username"] = loginModel.username;
                    Session["role"] = role;
                    if (role == "\"admin\"")
                        return RedirectToAction("Home", "Admin");
                    else
                        return RedirectToAction("Index", "Home");
                }
                catch(LoginException e)
                {
                    LoginError loginError = new LoginError();
                    loginError = JsonConvert.DeserializeObject<LoginError>(e.Message);
                    return View("Error", loginError);
                }
                catch (Exception e)
                {
                    LoginError loginError = new LoginError();
                    loginError.error_description = "Sorry! Something Went Wrong. Sorry for the inconvinience, we are constantly working on improving our systems.";
                    return View("Error", loginError);
                }
            }
            return View("Index");

        }

        public ActionResult Error(Exception e)
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }
    }
}
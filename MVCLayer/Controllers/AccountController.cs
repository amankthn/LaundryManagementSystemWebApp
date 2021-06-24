using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MVCLayer.Models;
namespace MVCLayer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public async Task<ActionResult> Index()
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                AccountBL accountBL = new AccountBL();
                string accounts = await accountBL.GetAccounts(Session["token"].ToString());
                List<Account> cust = JsonConvert.DeserializeObject<List<Account>>(accounts);
                return View(cust);
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {
                Session["accId"] = id;
                AccountBL accountBL = new AccountBL();
                string Accounts = await accountBL.GetAccounts(Session["token"].ToString());
                List<Account> acc = JsonConvert.DeserializeObject<List<Account>>(Accounts);
                return View(acc.Find(a => a.AccID == id));
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Account c)
        {
            if (Session["loggedIn"] != null && Session["role"].ToString() == "\"admin\"")
            {

                if (ModelState.IsValid)
                {
                    c.AccID = (int)Session["accId"];
                    AccountBL accountBL = new AccountBL();
                    string account = JsonConvert.SerializeObject(c);
                    string result = await accountBL.EditC(account, c.AccID, Session["token"].ToString());
                    string Accounts = await accountBL.GetAccounts(Session["token"].ToString());
                    List<Account> acc = JsonConvert.DeserializeObject<List<Account>>(Accounts);
                    return View("Index", acc);
                }
                return View("Edit");
            }
            else
            {
                return RedirectToAction("Unauthorized", "Error");
            }
        }
    }
}
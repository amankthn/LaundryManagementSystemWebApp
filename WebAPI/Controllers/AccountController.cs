using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Authorize(Roles ="admin")]
        public List<Account> GetAccounts()
        {
            AccountDBHelper accountDBHelper = new AccountDBHelper();
            return accountDBHelper.GetAccounts().ToList();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public bool Edit(Account c)
        {
            AccountDBHelper dBHelper = new AccountDBHelper();
            return dBHelper.EditAccount(c);
        }
    }
}

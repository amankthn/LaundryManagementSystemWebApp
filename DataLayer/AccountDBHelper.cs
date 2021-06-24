using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class AccountDBHelper
    {
        public DbSet<Account> GetAccounts()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Accounts;
        }

        public bool EditAccount(Account c)
        {
            try
            {
                LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
                Account cou = db.Accounts.Find(c.AccID);
                cou.AccStatus = c.AccStatus;
                cou.Cost = c.Cost;
                cou.Pending = c.Pending;
                db.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }

        
    }
}

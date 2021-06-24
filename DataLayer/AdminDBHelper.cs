using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class AdminDBHelper
    {
        public DbSet<Admin> GetAdmins()
        {
            LaundryManagementSystemEntities db = new LaundryManagementSystemEntities();
            return db.Admins;
        }
    }
}

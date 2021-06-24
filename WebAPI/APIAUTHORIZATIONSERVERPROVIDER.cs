using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using DataLayer;
namespace WebAPI
{
    public class APIAUTHORIZATIONSERVERPROVIDER : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            AdminDBHelper adminDb = new AdminDBHelper();
            CustomerDBHelper custDb = new CustomerDBHelper();
            bool found = false;
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            foreach (Admin a in adminDb.GetAdmins())
            {
                if (context.UserName == a.Username && context.Password == a.Password)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    //identity.AddClaim(new Claim("username", context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Hi" + context.UserName));
                    context.Validated(identity);
                    found = true;
                }
            }

            foreach (Customer c in custDb.GetCustomers())
            {
                if (context.UserName == c.Username && context.Password == c.Password)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    //identity.AddClaim(new Claim("username", context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Hi" + context.UserName));
                    context.Validated(identity);
                    found = true;
                }
            }   
            if(!found)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }            
        }
    }
}
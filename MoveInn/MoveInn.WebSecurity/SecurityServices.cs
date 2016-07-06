using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using MoveInn.WebSecurity.Models;

namespace MoveInn.WebSecurity
{
    public class SecurityServices : ICustomAuthentication
    {
        public bool Authenticate(string email, string password, bool ispersistent)
        {
            SecurityDataServices ds = new SecurityDataServices();

            if (!ds.CheckCredentials(email, password))
                return false;

            var authTicket = new FormsAuthenticationTicket(1, email, DateTime.Now,
                                               DateTime.Now.AddSeconds(30), ispersistent, "");

            string cookieContents = FormsAuthentication.Encrypt(authTicket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            return true;
        }

        public void CreateCustomPrincipal()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new CustomPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }
    }
}

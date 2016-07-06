using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoveInn.WebSecurity.Pipeline
{
    public class HttpSecurityPipeline : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.ApplicationAuthRequest);
        }

        protected void ApplicationAuthRequest(object sender, EventArgs args)
        {
            new WebSecurity.SecurityServices().CreateCustomPrincipal();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoveInn.WebSecurity.Filters
{
    public sealed class Authenticate : AuthorizeAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //  if (filterContext.ActionDescriptor.IsDefined(typeof(Authenticate), true))
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                return;

            //if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymous), true))
            //  return;

            throw new Exception("User not authorized");
        }
    }
}

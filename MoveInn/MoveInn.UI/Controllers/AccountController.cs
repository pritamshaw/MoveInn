using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using MoveInn.BAL.Services;
using MoveInn.DAL.Interfaces;
using MoveInn.WebSecurity;

namespace MoveInn.UI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            UserLogin Model = new UserLogin();
            return View(Model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin model, string returnUrl)
        {
            SecurityServices service = new SecurityServices();

            if (ModelState.IsValid && service.Authenticate(model.Email, model.Password, model.RememberMe))
            {
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult User()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoveInn.Web.Controllers
{
    public class PropertyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PropertyDetail()
        {
            ViewBag.Message = "Property detail page.";

            return View();
        }
    }
}
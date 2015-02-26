using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Collections.Specialized;

namespace DakkaWeb.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";

            return View();
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }
    }
}

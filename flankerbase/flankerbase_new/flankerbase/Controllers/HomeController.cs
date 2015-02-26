using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flankerbase.Models;
using flankerbase.Helpers;

namespace flankerbase.Controllers
{
    [HandleError]
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            if (Request["model"] != null)
            {
                if (String.Equals(Request["model"].ToString(), "D", StringComparison.CurrentCultureIgnoreCase))
                {
                    HttpCookie cookie = new HttpCookie("model", "D");
                    this.HttpContext.Response.Cookies.Add(cookie);
                    return View();
                }
                else if (String.Equals(Request["model"].ToString(), "M", StringComparison.CurrentCultureIgnoreCase))
                {
                    HttpCookie cookie = new HttpCookie("model", "M");
                    this.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("MobileIndex");
                }
            }

            if (IsMobileDevice)
            {
                return RedirectToAction("MobileIndex");
            }

            return View();
        }

        public ActionResult MobileIndex()
        {
            HttpCookie cookie = new HttpCookie("model", "M");
            this.HttpContext.Response.Cookies.Add(cookie);
            return MobileView("Home");
        }

        public ActionResult About()
        {
            return View(AboutDTO.GetAboutDTO());
        }

        public ActionResult MobileAbout()
        {
            return MobileView("About", AboutDTO.GetAboutDTO());
        }

        public ActionResult Social()
        {
            return View();
        }
    }
}

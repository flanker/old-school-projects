using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCache.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }



        public ActionResult CommonHttpRequest()
        {
            ViewData["result"] = GetResult();

            return View();
        }

        public ActionResult AjaxRequest()
        {
            return View();
        }

        public ActionResult HttpCache()
        {
            return View();
        }

        public ActionResult LocalStorage()
        {
            return View();
        }

        public ContentResult GetAjaxResult()
        {
            string result = GetResult();

            return Content(result);
        }

        public ContentResult GetAjaxResultWithHttpCache()
        {
            if (Request.Headers["If-Modified-Since"] != null)
            {
                DateTime requestDate = DateTime.Parse(Request.Headers["If-Modified-Since"].ToString());
                if (requestDate.AddSeconds(10) > DateTime.Now)
                {
                    Response.SuppressContent = true;
                    Response.StatusCode = 304;
                    Response.StatusDescription = "Not Modified";
                    // Explicitly set the Content-Length header so the client doesn't wait for
                    // content but keeps the connection open for other requests
                    Response.AddHeader("Content-Length", "0");

                    return null;
                }
            }

            string result = GetResult();

            Response.Cache.SetLastModified(DateTime.Now);

            return Content(result);
        }

        private string GetResult()
        {
            System.Threading.Thread.Sleep(2000);

            return DateTime.Now.ToString();
        }
    }
}

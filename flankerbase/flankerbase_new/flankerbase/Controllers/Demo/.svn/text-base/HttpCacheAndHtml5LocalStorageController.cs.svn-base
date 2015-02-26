using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace flankerbase.Controllers
{
    public class Http_Cache_And_Html5_Local_StorageController : ControllerBase
    {

        private ActionResult ThisView(string viewName)
        {
            return View("~/Views/Demo/Http_Cache_And_Html5_Local_Storage/" + viewName + ".aspx");
        }

        private string GetServerResult()
        {
            System.Threading.Thread.Sleep(5000);

            return DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss") + " GMT";
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage

        public ActionResult Index()
        {
            return ThisView("Index");
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Regular_Http_Request

        public ActionResult Regular_Http_Request()
        {
            string result = GetServerResult();
            ViewData["result"] = result;

            return ThisView("Regular_Http_Request");
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Ajax_Http_Request

        public ActionResult Ajax_Http_Request()
        {
            return ThisView("Ajax_Http_Request");
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Http_Cache

        public ActionResult Http_Cache()
        {
            return ThisView("Http_Cache");
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Ajax_Get_Result
        
        public ContentResult Ajax_Get_Result()
        {
            string result = GetServerResult();

            return Content(result);
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Ajax_Get_Result_With_Cache

        public ContentResult Ajax_Get_Result_With_Cache()
        {
            if (Request.Headers["If-Modified-Since"] != null)
            {
                DateTime requestDate = DateTime.Parse(Request.Headers["If-Modified-Since"].ToString());
                if (requestDate.AddSeconds(10) > DateTime.Now)
                {
                    Response.SuppressContent = true;
                    Response.StatusCode = 304;
                    Response.StatusDescription = "Not Modified";
                    Response.AddHeader("Content-Length", "0");

                    return null;
                }
            }

            string result = GetServerResult();
            Response.Cache.SetLastModified(DateTime.Now);
            return Content(result);
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Html5_Local_Storage

        public ActionResult Html5_Local_Storage()
        {
            return ThisView("Html5_Local_Storage");
        }

        //
        // GET: /Demo/Http_Cache_And_Html5_Local_Storage/Ajax_Html5_Local_Storage

        public ContentResult Ajax_Html5_Local_Storage()
        {
            string result = GetServerResult();

            return Content(result);
        }

    }
}

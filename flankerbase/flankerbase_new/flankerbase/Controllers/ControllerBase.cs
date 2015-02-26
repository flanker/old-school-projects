using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flankerbase.Helpers;

namespace flankerbase.Controllers
{
    public class ControllerBase : Controller
    {
        protected bool IsMobileDevice
        {
            get
            {
                if (this.Request.Cookies["model"] != null && String.Equals(this.Request.Cookies["model"].Value, "M", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                else if (this.Request.Cookies["model"] != null && String.Equals(this.Request.Cookies["model"].Value, "D", StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }

                if (this.Request.UserAgent.IndexOf("Mobile", StringComparison.CurrentCultureIgnoreCase) > 0)
                {
                    return true;
                }
                else if (this.Request.UserAgent.IndexOf("Android", StringComparison.CurrentCultureIgnoreCase) > 0)
                {
                    return true;
                }
                else if (this.Request.UserAgent.IndexOf("UCWEB", StringComparison.CurrentCultureIgnoreCase) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //private bool IsMobileDevice { get { return this.Request.UserAgent.IndexOf("IEMobile") > 0; } }

        protected ActionResult MobileView(string viewName)
        {
            return View("Mobile/" + viewName);
        }

        protected ActionResult MobileView(string viewName, object model)
        {
            return View("Mobile/" + viewName, model);
        }

        protected ActionResult SelectView(string viewName, object model)
        {
            if (IsMobileDevice)
            {
                return MobileView(viewName, model);
            }
            else
            {
                return View(viewName, model);
            }
        }

        // **********************************************

        public PermanentRedirectResult PermanentRedirect(string actionName)
        {
            string url = Url.Action(actionName);
            return new PermanentRedirectResult(url);
        }
    }
}

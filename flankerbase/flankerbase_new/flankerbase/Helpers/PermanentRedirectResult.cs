using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flankerbase.Helpers
{
    public class PermanentRedirectResult : ActionResult
    {
        private string _url;

        public PermanentRedirectResult(string url)
        {
            _url = url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 301;
            context.HttpContext.Response.RedirectLocation = _url;
        }
    }
}

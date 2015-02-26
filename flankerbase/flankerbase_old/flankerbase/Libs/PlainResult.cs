using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flankerbase.Libs
{
    sealed class PlainResult : ActionResult
    {
        private string _Content;

        public PlainResult(string content)
        {
            _Content = content;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(_Content);
            context.HttpContext.Response.End();
        }
    }
}

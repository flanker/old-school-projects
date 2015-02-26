using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace DakkaWeb.Filters
{
    public class ExceptionToJsonFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.Result = new JsonResult()
            {
                Data = new { success = false, msg = filterContext.Exception.Message }
            };

            filterContext.ExceptionHandled = true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DakkaWeb.Filters
{
    public class ExceptionToViewFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary() { { "ErrorMessage", "在Action中发生了未处理的异常: " + filterContext.Exception.Message + "  " + filterContext.Exception.StackTrace } }
            };

            filterContext.ExceptionHandled = true;
        }
    }
}

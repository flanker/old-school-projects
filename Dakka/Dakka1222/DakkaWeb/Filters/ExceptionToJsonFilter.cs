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
                Data = new { 
                    success = false, 
                    msg = "在Action中发生了未处理的异常: " 
                        + filterContext.Exception.Message + "  " 
                        + filterContext.Exception.StackTrace }
            };

            filterContext.ExceptionHandled = true;

        }
    }
}

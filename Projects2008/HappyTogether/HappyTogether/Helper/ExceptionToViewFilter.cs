using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace HappyTogether.Helper
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
                ViewName = "Error2",
                ViewData = new ViewDataDictionary() { 
                    { "ErrorMessage", "在Action中发生了未处理的异常: " + filterContext.Exception.Message + "  " + filterContext.Exception.StackTrace } }
            };

            filterContext.ExceptionHandled = true;


            StringBuilder sb = new StringBuilder();
            sb.Append("在Action中发生了未处理的异常" + Environment.NewLine);
            sb.Append("RawUrl: " + filterContext.HttpContext.Request.RawUrl + Environment.NewLine);
            sb.Append("User: " + filterContext.HttpContext.User.Identity.Name + Environment.NewLine);
            sb.Append("TargetSite: " + filterContext.Exception.TargetSite + Environment.NewLine);
            sb.Append("Exception: " + filterContext.Exception.ToString() + Environment.NewLine);

            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Error(sb.ToString());


        }
    }
}

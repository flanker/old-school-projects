using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using DakkaData;

namespace DakkaWeb
{
    public class ExceptionToJsonFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            Exception ex = filterContext.Exception;

            if (ex is BaseException)
            {
                BaseException be = ex as BaseException;
                filterContext.Result = new JsonResult()
                {
                    Data = new
                    {
                        success = false,
                        msg = be.Message
                    }
                };
            }
            else
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new
                    {
                        success = false,
                        msg = "在Action中发生了未处理的异常: "
                            + ex.Message + "  "
                            + ex.StackTrace
                    }
                };
            }

            filterContext.ExceptionHandled = true;

        }
    }
}

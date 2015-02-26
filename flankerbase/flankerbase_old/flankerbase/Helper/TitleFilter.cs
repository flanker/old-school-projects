using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flankerbase
{
    public class TitleAttribute : FilterAttribute, IActionFilter
    {
        private string _title;

        public TitleAttribute(string Title)
        {
            _title = Title;
        }

        #region IActionFilter 成员

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData["Title"] = String.Format("flanker base - {0}", _title);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }

        #endregion
    }
}

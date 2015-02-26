using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace HappyTogether.Helper
{
    public class LoggerFilter : FilterAttribute, IActionFilter
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private LogType _logType;

        public LoggerFilter()
            : this(LogType.None)
        {
        }

        public LoggerFilter(LogType LogType)
        {
            _logType = LogType;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_logType == LogType.OnExecuting
                || _logType == LogType.Both)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("OnActionExecuting" + Environment.NewLine);
                sb.Append("RawUrl: " + filterContext.HttpContext.Request.RawUrl + Environment.NewLine);
                sb.Append("User: " + filterContext.HttpContext.User.Identity.Name + Environment.NewLine);
                foreach (string key in filterContext.ActionParameters.Keys)
                {
                    sb.Append("key: " + key);
                    sb.Append("\tValue: " + filterContext.ActionParameters[key].ToString());
                    sb.Append(Environment.NewLine);
                }
                logger.Trace(sb.ToString());
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_logType == LogType.OnExecuted
                || _logType == LogType.Both)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("OnActionExecuted" + Environment.NewLine);
                sb.Append("RawUrl: " + filterContext.HttpContext.Request.RawUrl + Environment.NewLine);
                sb.Append("User: " + filterContext.HttpContext.User.Identity.Name + Environment.NewLine);
                logger.Trace(sb.ToString());
            }
        }

    }

    public enum LogType
    {
        None = 0,
        OnExecuting,
        OnExecuted,
        Both
    }
}

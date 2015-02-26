using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flankerbase.Helpers
{
    public class AcceptDevice : FilterAttribute, IActionFilter
    {
        private Device Device { get; set; }

        public AcceptDevice(Device device)
        {
            this.Device = device;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            switch (Device)
            {
                case Device.Desktop:
                    if (filterContext.HttpContext.Request.Browser.IsMobileDevice)
                    {
                        //filterContext.Controller.
                    }
                    break;
                case Device.Mobile:
                    break;
                case Device.Both:
                    break;
                default:
                    break;
            }
        }

    }

    public enum Device
    {
        Desktop,
        Mobile,
        Both
    }
}

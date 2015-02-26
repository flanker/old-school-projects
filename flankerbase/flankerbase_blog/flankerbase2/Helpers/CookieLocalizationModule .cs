using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace flankerbase2.Helpers
{
    public class CookieLocalizationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            // eat the cookie (if any) and set the culture
            if (HttpContext.Current.Request.Cookies["lang"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
                string lang = cookie.Value;
                var culture = new System.Globalization.CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }
    }
}

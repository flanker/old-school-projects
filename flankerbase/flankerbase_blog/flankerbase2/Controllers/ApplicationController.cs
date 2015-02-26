using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using flankerbase2.Models;

namespace flankerbase2.Controllers
{
    public class ApplicationController : Controller
    {
        protected BlogRepository repo = new BlogRepository();
    }
}

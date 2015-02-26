using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NLog;
using HappyTogether.Models;

namespace HappyTogether.Controllers
{
    public class AppControllerBase : Controller
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        protected TogetherRepository TogetherRepository = new TogetherRepository();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;

namespace flankerbase.Controllers
{
    public class AccountController : AppControllerBase
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string userName, string password)
        {
            // 校验用户名密码
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            FormsAuthentication.SetAuthCookie(userName, true);

            // 转向通过认证后的页面
            return RedirectToAction("Index", "Home");

        }

        public ActionResult LogOff()
        {
            // 取消认证票据
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "用户名不能为空。");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "密码不能为空。");
            }
            if (!Membership.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "用户名和密码不正确。");
            }

            return ModelState.IsValid;
        }



    }
}

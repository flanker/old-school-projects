using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;

namespace MVCSzzz.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("username", "�û�������Ϊ��!");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "���벻��Ϊ��!");
            }
            if (!Membership.ValidateUser(username, password))
            {
                ModelState.AddModelError("_FORM", "�û������벻��ȷ");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}

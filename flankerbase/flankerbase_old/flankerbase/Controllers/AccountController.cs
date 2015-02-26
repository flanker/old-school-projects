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
            // У���û�������
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            FormsAuthentication.SetAuthCookie(userName, true);

            // ת��ͨ����֤���ҳ��
            return RedirectToAction("Index", "Home");

        }

        public ActionResult LogOff()
        {
            // ȡ����֤Ʊ��
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "�û�������Ϊ�ա�");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "���벻��Ϊ�ա�");
            }
            if (!Membership.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", "�û��������벻��ȷ��");
            }

            return ModelState.IsValid;
        }



    }
}

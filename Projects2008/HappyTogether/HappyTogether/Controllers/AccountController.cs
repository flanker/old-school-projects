using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using HappyTogether.Helper;

namespace HappyTogether.Controllers
{
    [HandleError]
    public class AccountController : AppControllerBase
    {
        [ExceptionToViewFilter]
        public ActionResult LogOn()
        {
            return View();
        }

        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {
            // 校验用户名密码
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            // 添加通过认证的票据
            SignIn(userName, rememberMe);

            // 转向通过认证后的页面
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [ExceptionToViewFilter]
        public ActionResult LogOff()
        {
            // 取消认证票据
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [ExceptionToViewFilter]
        public ActionResult Register()
        {
            ViewData["PasswordLength"] = Membership.MinRequiredPasswordLength;
            return View();
        }

        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, string email, string password, string confirmPassword)
        {
            ViewData["PasswordLength"] = Membership.MinRequiredPasswordLength;

            // 校验注册用户信息
            if (ValidateRegistration(userName, email, password, confirmPassword))
            {
                // 尝试新增用户到数据库中
                MembershipCreateStatus createStatus;
                Membership.CreateUser(userName, password, email, null, null, true, out createStatus);

                // 新增成功
                if (createStatus == MembershipCreateStatus.Success)
                {
                    SignIn(userName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // 返回错误
                    ModelState.AddModelError("_FORM", ErrorCodeToString(createStatus));
                }
            }

            // 注册失败，返回让用户修改错误
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        #region 认证相关辅助方法

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

        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "用户名不能为空。");
            }
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "Email不能为空。");
            }
            int i;
            if (Int32.TryParse(userName, out i))
            {
                ModelState.AddModelError("username", "用户名不能全为数字。");
            }
            if (password == null || password.Length < Membership.MinRequiredPasswordLength)
            {
                ModelState.AddModelError("password",
                    String.Format(CultureInfo.CurrentCulture,
                         "密码不能少于{0}位。",
                         Membership.MinRequiredPasswordLength));
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "密码和确认密码不一致。");
            }

            return ModelState.IsValid;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // 参照 http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx
            // 状态信息列表
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已经存在，请选择另一个用户名。";

                case MembershipCreateStatus.DuplicateEmail:
                    return "该Email地址已被使用，请输入一个其他的Email地址。";

                case MembershipCreateStatus.InvalidPassword:
                    return "提供的密码不符合要求。";

                case MembershipCreateStatus.InvalidEmail:
                    return "提供的Email地址不合法。";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        private void SignIn(string userName, bool createPersistentCookie)
        {

            Logger.Trace("认证Local用户: " + userName);
            Logger.Trace("给Local用户添加包含UserData的认证票据, 重发送至首页");

            // 生成UserData
            string userDataString = string.Concat(userName, "|", "/Content/Images/tinyHead.gif");

            // 创建包含认证用户信息的Cookie
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie);

            // 获得解密后的认证票据
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            // 创建一个新的包含UserData的认证票据
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

            // 加密新的认证票据
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);

            // 手工将认证票据加入Cookie
            Response.Cookies.Add(authCookie);
        }

        #endregion
    }

}

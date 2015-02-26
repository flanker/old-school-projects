using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HappyTogether.Helper;
using HappyTogether.Models;

namespace HappyTogether.Controllers
{
    [HandleError]
    public class HomeController : AppControllerBase
    {
        private readonly string SECRET = "097499ad6ec04595b61fe9cd6438d6ef";
        private readonly string APIKEY = "b77debeb2b404e72af9b0f3e125d1e59";

        [ExceptionToViewFilter]
        public ActionResult Index()
        {
            #region 认证从校内网登录的用户

            string user = this.Request["xn_sig_user"];
            string sessionkey = this.Request["xn_sig_session_key"];

            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(sessionkey))
            {
                Logger.Trace("对/Home/Index的请求中发现User和SessionKey" + Environment.NewLine
                    + "    User: " + user + Environment.NewLine
                    + "    SessionKey: " + sessionkey);

                ViewData["USER"] = user;
                ViewData["SESSION"] = sessionkey;

                string encodedSessionKey = HttpUtility.UrlEncode(sessionkey);
                var client = new Xiaonei.API.APIClient(APIKEY, SECRET, encodedSessionKey);
                Xiaonei.XmlSchema.user you = client.UsersGetInfo(user, "name,tinyurl,uid").First();
                Logger.Trace("调用校内API, 获取用户UID, Name, TinyURL");
                if (!User.Identity.IsAuthenticated)
                {
                    Logger.Trace("认证Xiaonei用户: " + you.name + " (" + you.uid + ")");
                    Logger.Trace("给Xiaonei用户添加包含UserData的认证票据, 重发送至首页");

                    // 生成UserData
                    string userDataString = string.Concat(you.name, "|", you.tinyurl);

                    // 创建包含认证用户信息的Cookie
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(you.uid.ToString(), true);

                    // 获得解密后的认证票据
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    // 创建一个新的包含UserData的认证票据
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                        ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);

                    // 加密新的认证票据
                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                    // 手工将认证票据加入Cookie
                    Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index");
                }
            }

            #endregion

            SelectList togetherTypes = TogetherFormViewModel.CreateTogetherTypesWithAll();

            return View(togetherTypes);
        }

        [ExceptionToViewFilter]
        public ActionResult About()
        {
            return View();
        }
    }
}

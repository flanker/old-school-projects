using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace HappyTogether.Helper
{
    public static class IIdentityExtend
    {
        public static string UserName(this IIdentity identity)
        {
            if (identity is FormsIdentity)
            {
                string[] userDataPieces = (identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray());
                return userDataPieces[0];
            }
            else
            {
                throw new Exception("UserName only supported by FormsIdentity.");
            }
        }

        public static string TinyURL(this IIdentity identity)
        {
            if (identity is FormsIdentity)
            {
                string[] userDataPieces = (identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray());
                return userDataPieces[1];
            }
            else
            {
                throw new Exception("TinyURL only supported by FormsIdentity.");
            }
        }
    }
}

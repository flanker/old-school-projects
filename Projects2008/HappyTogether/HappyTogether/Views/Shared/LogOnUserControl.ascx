<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="HappyTogether.Helper" %>
<%
    if (Request.IsAuthenticated)
    {
%>
欢迎你，<%= Html.ImageEncode(Page.User.Identity.TinyURL(), Page.User.Identity.UserName()) %>
<b>
    <%= Html.Encode(Page.User.Identity.UserName()) %></b>！
<% int i;
   if (!int.TryParse(Page.User.Identity.Name, out i))
   { %>
[
<%= Html.ActionLink("注销", "LogOff", "Account") %>
]
<%} %>
<%
    }
    else
    {
%>
[
<%= Html.ActionLink("登陆", "LogOn", "Account") %>
<%= Html.ActionLink("注册", "Register", "Account") %>
]
<%
    }
%>

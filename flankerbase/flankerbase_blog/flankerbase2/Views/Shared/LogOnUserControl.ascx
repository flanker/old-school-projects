<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated)
    {
%>
<span class="highContrast">
    <%= Strings.welcome %>
    <%= Html.Encode(Page.User.Identity.Name) %>!</span>
<%= Html.ActionLink(Strings.logoff, "LogOff", "Account", null, new { @class = "highContrast" })%>
<%
    }
    else
    {
%>
<%= Html.ActionLink(Strings.logon, "LogOn", "Account", null, new { @class = "highContrast" })%>
<%
    }
%>

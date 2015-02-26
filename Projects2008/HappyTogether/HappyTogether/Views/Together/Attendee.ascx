<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Together>" %>
<div id="attendeemsg">
    <% if (Request.IsAuthenticated)
       { %>
    <% if (Model.IsUserRegistered(Context.User.Identity.Name))
       { %>
    <p>你已经参与了这个活动。</p>
    <%}
       else
       {%>
    <p>
        <%= Ajax.ActionLink("参加这个活动", "Register", "Attendee",
            new { id = Model.TogetherID },
            new AjaxOptions { UpdateTargetId = "attendeemsg", OnSuccess = "AnimateAttendeeMessage" })%></p>
    <%} %>
    <%}
       else
       { %>
    <p>
        <%= Html.ActionLink("登录", "Logon", "Account", new { returnUrl = Request.RawUrl }, null)%>
        来参加这个活动。</p>
    <%} %>
</div>

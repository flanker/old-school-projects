<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Together>" %>
<div id="attendeemsg">
    <% if (Request.IsAuthenticated)
       { %>
    <% if (Model.IsUserRegistered(Context.User.Identity.Name))
       { %>
    <p>���Ѿ�������������</p>
    <%}
       else
       {%>
    <p>
        <%= Ajax.ActionLink("�μ�����", "Register", "Attendee",
            new { id = Model.TogetherID },
            new AjaxOptions { UpdateTargetId = "attendeemsg", OnSuccess = "AnimateAttendeeMessage" })%></p>
    <%} %>
    <%}
       else
       { %>
    <p>
        <%= Html.ActionLink("��¼", "Logon", "Account", new { returnUrl = Request.RawUrl }, null)%>
        ���μ�������</p>
    <%} %>
</div>

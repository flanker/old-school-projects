<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NerdDinner.Models.Dinner>" %>
<div id="rsvpmsg">
    <% if (Request.IsAuthenticated)
       { %>
    <% if (Model.IsUserRegistered(Context.User.Identity.Name))
       { %>
    <p>You are registered for this dinner!</p>
    <%}
       else
       {%>
    <p>
        <%= Ajax.ActionLink("RSVP for this dinner", "Register", "RSVP",
            new { id = Model.DinnerID }, 
            new AjaxOptions{ UpdateTargetId = "rsvpmsg", OnSuccess="AnimateRSVPMessage" })  %></p>
    <%} %>
    <%}
       else
       { %>
    <p>
        <%= Html.ActionLink("Logon","Logon","Account") %>
        to RSVP for this dinner.</p>
    <%} %>
</div>

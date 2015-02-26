<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Post>" %>
<% if (Request.IsAuthenticated)
   {
%>
<div id="postForm">
    <%= Html.ValidationSummary("¡Ù—‘ ß∞‹£¨«Î–ﬁ∏ƒ¥ÌŒÛ≤¢÷ÿ–¬Ã·Ωª°£") %>
    <% using (Html.BeginForm())
       {%>
    <p>
        <%= Html.Hidden("TogetherID") %>
        <input type="submit" value="¡Ù—‘" />
        <%= Html.TextBox("PostContent") %>
        <%= Html.ValidationMessage("PostContent", "*") %>
    </p>
    <% } %>
</div>
<%      
    }
   else
   { %>
<p>
    <%= Html.ActionLink("µ«¬º", "Logon", "Account", new { returnUrl = Request.RawUrl }, null)%>
    ¿¥¡Ù—‘</p>
<%} %>

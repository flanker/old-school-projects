<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Post>" %>
<% if (Request.IsAuthenticated)
   {
%>
<div id="postForm">
    <%= Html.ValidationSummary("����ʧ�ܣ����޸Ĵ��������ύ��") %>
    <% using (Html.BeginForm())
       {%>
    <p>
        <%= Html.Hidden("TogetherID") %>
        <input type="submit" value="����" />
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
    <%= Html.ActionLink("��¼", "Logon", "Account", new { returnUrl = Request.RawUrl }, null)%>
    ������</p>
<%} %>

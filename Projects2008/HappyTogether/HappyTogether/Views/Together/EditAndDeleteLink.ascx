<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Together>" %>
<% if (Model.IsHostedBy(Context.User.Identity.Name))
   { %>
<%= Html.ActionLink("�޸Ļ", "Edit", new { id=Model.TogetherID })%>
|
<%= Html.ActionLink("ɾ���", "Delete", new { id = Model.TogetherID })%>
<% } %>
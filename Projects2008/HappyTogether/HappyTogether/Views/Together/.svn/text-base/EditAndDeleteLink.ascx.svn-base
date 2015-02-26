<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Together>" %>
<% if (Model.IsHostedBy(Context.User.Identity.Name))
   { %>
<%= Html.ActionLink("修改活动", "Edit", new { id=Model.TogetherID })%>
|
<%= Html.ActionLink("删除活动", "Delete", new { id = Model.TogetherID })%>
<% } %>
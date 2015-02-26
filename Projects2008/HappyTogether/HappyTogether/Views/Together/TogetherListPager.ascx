<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Helper.PaginatedList<HappyTogether.Models.Together>>" %>
<% if (Model.HasNextPage)
   { 
%>
<%= Html.RouteLink("下一页", "Together", new { page = (Model.PageIndex + 1) })%>
<% } %>
<% if (Model.HasPreviousPage)
   {
%>
<%= Html.RouteLink("上一页", "Together", new { page = (Model.PageIndex - 1) })%>
<% } %>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Helper.PaginatedList<HappyTogether.Models.Together>>" %>
<% if (Model.HasNextPage)
   { 
%>
<%= Html.RouteLink("��һҳ", "Together", new { page = (Model.PageIndex + 1) })%>
<% } %>
<% if (Model.HasPreviousPage)
   {
%>
<%= Html.RouteLink("��һҳ", "Together", new { page = (Model.PageIndex - 1) })%>
<% } %>

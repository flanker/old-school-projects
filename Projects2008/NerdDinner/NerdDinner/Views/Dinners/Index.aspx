<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NerdDinner.Helper.PaginatedList<NerdDinner.Models.Dinner>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Upcoming
    Dinners </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upcoming Dinners</h2>
    <ul>
        <% foreach (var dinner in Model)
           { %>
        <li>
            <%= Html.ActionLink(dinner.Title,"Details",new { id=dinner.DinnerID}) %>
            on
            <%= Html.Encode(dinner.EventDate.ToShortDateString())%>
            @
            <%= Html.Encode(dinner.EventDate.ToShortTimeString())%>
        </li>
        <% } %>
    </ul>
    <% if (Model.HasNextPage)
       { 
    %>
    <%= Html.RouteLink("Next","Dinners",new { page = (Model.PageIndex +1)}) %>
    <% } %>
    <% if (Model.HasPreviousPage)
       {
    %>
    <%= Html.RouteLink("Prev","Dinners", new { page = (Model.PageIndex -1)}) %>
    <% } %>
</asp:Content>

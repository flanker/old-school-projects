<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<flankerbase.Models.ToolDTO>>" %>
<div>
    <% foreach (var item in Model)
       { %>
    <div class="item">
        <div class="item-name">
            <%= Html.Encode(item.Name) %></div>
        <div class="item-description">
            <%= Html.Encode(item.Description) %>
            <a href="http://www.google.com/search?q=<%= Url.Encode(item.Name) %>" title="<%= Html.Encode(item.Name) %>" rel="external">Google it!</a></div>
    </div>
    <% } %>
</div>

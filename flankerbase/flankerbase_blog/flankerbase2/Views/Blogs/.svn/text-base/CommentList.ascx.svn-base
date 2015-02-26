<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<flankerbase2.Models.Comment>>" %>
<table>
    <tr>
        <th>Name </th>
        <th>Email </th>
        <th>Content </th>
        <th>Created_at </th>
    </tr>
    <% foreach (var item in Model)
       { %>
    <tr>
        <td>
            <%= Html.Encode(item.Name) %>
        </td>
        <td>
            <%= Html.Encode(item.Email) %>
        </td>
        <td>
            <%= Html.Encode(item.Content) %>
        </td>
        <td>
            <%= Html.Encode(String.Format("{0:g}", item.Created_at)) %>
        </td>
    </tr>
    <% } %>
</table>

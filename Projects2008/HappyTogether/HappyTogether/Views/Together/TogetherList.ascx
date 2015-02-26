<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<HappyTogether.Models.Together>>" %>
<%@ Import Namespace="HappyTogether.Helper" %>
<div id="togetherList">
    <ul>
        <% foreach (var together in Model)
           { %>
        <li>
            <span class="thumb">
                <%= Html.ImageEncode(together.PicURL, "�ͼƬ") %></span>
            <span class="together-body">
                <span>
                    <%= Html.ActionLink(together.Title, "Details", new { id = together.TogetherID }) %></span>
                <span>��֯�ߣ�<%= Html.Encode(together.HostedBy) %></span>
                <span>����ͣ�<%= Html.Encode(together.TogetherTypeString) %></span>
                <span>�ʱ�䣺<%= together.StartDate.ToLocalTime() %></span>
                <span>���ַ��<%= Html.Encode(together.Address) %></span>
                <span>���� <%= together.Attendees.Count %> �˲μ�</span>
            </span>
        </li>
        <% } %>
    </ul>
</div>

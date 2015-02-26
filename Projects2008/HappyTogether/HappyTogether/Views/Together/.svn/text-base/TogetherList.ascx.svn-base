<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<HappyTogether.Models.Together>>" %>
<%@ Import Namespace="HappyTogether.Helper" %>
<div id="togetherList">
    <ul>
        <% foreach (var together in Model)
           { %>
        <li>
            <span class="thumb">
                <%= Html.ImageEncode(together.PicURL, "活动图片") %></span>
            <span class="together-body">
                <span>
                    <%= Html.ActionLink(together.Title, "Details", new { id = together.TogetherID }) %></span>
                <span>组织者：<%= Html.Encode(together.HostedBy) %></span>
                <span>活动类型：<%= Html.Encode(together.TogetherTypeString) %></span>
                <span>活动时间：<%= together.StartDate.ToLocalTime() %></span>
                <span>活动地址：<%= Html.Encode(together.Address) %></span>
                <span>已有 <%= together.Attendees.Count %> 人参加</span>
            </span>
        </li>
        <% } %>
    </ul>
</div>

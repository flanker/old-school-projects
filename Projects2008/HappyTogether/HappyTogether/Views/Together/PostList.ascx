<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HappyTogether.Models.Post>>" %>
<%@ Import Namespace="HappyTogether.Helper" %>
<div id="postList">
<ul>
    <% foreach (var post in Model)
       { %>
    <li>
        <span class="thumb">
            <%= Html.ImageEncode(post.TinyURL, post.UserName) %></span>
        <span class="post-body"><strong>
            <%= Html.Encode(post.UserName) %></strong>
            <span class="post-time">
                <%= Html.Encode(post.PostDate.ToLocalTime()) %></span>
            <span class="post-content-out">
            <span class="post-content">
                <%= Html.Encode(post.PostContent) %></span></span>
        </span>
    </li>
    <% } %>
</ul></div>

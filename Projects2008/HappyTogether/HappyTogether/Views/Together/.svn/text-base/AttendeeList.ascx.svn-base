<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HappyTogether.Models.Attendee>>" %>
<%@ Import Namespace="HappyTogether.Helper" %>
<% 
    var atts = Model.OrderByDescending(a => a.AttendeeID);
%>
<p>最新参与的用户</p>
<ul>
    <% foreach (var attendee in atts)
       { %>
    <li>
        <span class="thumb">
            <%= Html.ImageEncode(attendee.TinyURL, attendee.UserName)%></span>
        <span class="username"><strong>
            <%= Html.Encode(attendee.UserName)%></strong></span>
    </li>
    <% } %>
</ul>
<p class="clear"><a href="#" title="查看全部">查看全部</a></p>

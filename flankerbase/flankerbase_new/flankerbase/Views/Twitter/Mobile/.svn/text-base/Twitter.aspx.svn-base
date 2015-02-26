<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase.Models.TwitterDTO>>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">我的推特 - 超级无敌 - 冯智超的个人网站 - 移动版</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>我的推特</h1>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentContent" runat="server">
    <p>Please follow me <a href="http://twitter.com/flankerfc">@flankerfc</a></p>
    <ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
        <li data-role="list-divider">我的推特</li>
        <% foreach (var item in Model)
           { %>
        <li>
            <%= Html.Encode(item.Text) %></li>
        <% } %>
    </ul>
</asp:Content>

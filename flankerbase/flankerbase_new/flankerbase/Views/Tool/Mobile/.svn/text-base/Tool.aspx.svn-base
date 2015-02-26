<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase.Models.ToolDTO>>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">我的常用工具 - 超级无敌 - 冯智超的个人网站 - 移动版</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>我的常用工具</h1>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentContent" runat="server">
    <p>常用的一些工具, 记录在这里. 点击栏目直接进入Google移动版搜索页面</p>
    <ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
        <li data-role="list-divider">常用工具</li>
        <% foreach (var item in Model)
           { %>
        <li><a href="http://www.google.com/m/search?q=<%= Url.Encode(item.Name) %>" title="<%= Html.Encode(item.Name) %>" rel="external">
            <%= Html.Encode(item.Name) %></a></li>
        <% } %>
    </ul>
</asp:Content>

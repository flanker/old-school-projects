<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.AboutDTO>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    关于我 - 超级无敌 - 冯智超的个人网站 - 移动版
</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>关于我</h1>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentContent" runat="server">
    <p>关于我的一些信息</p>
    <ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
        <li data-role="list-divider">我的关键词</li>
        <% foreach (string tag in Model.Tags)
           { %>
           <li><%= tag %>;</li>
        <% } %>
    </ul>
</asp:Content>

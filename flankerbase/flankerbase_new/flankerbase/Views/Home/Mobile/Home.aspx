<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">超级无敌 - 冯智超的个人网站 - 移动版</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>超级无敌</h1>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentContent" runat="server">
    <p>超级无敌 - 冯智超的个人网站 - 移动版. 欢迎访问.</p>
    <ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
        <li data-role="list-divider">首页信息</li>
        <li><a href="/m/about">关于我</a></li>
        <li><a href="http://blog.chaojiwudi.com">我的博客</a></li>
        <li><a href="/m/twitter">我的推特</a></li>
        <li><a href="/m/tool">常用工具</a></li>
        <li><a href="/m/demo">Demo示例</a></li>
    </ul>
</asp:Content>

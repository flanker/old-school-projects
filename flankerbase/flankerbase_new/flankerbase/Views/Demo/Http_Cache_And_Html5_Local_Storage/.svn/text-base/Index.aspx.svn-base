<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Demo.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Http 缓存和 Html5 本地存储</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server"></asp:Content>
<asp:Content ID="DemoNavBlog" ContentPlaceHolderID="DemoNavBlogPlaceHolder" runat="server">
    <p class="demo-Nav-Blog"><a href="http://blog.chaojiwudi.com/2010/12/http_cache_and_html5_local_storage/" title="使用 Http 缓存和 Html5 本地存储提升 Web 服务响应速度 | 宇宙超级无敌 | 冯智超的博客">关于本 demo 的博客文章</a></p>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">demo - Http 缓存和 Html5 本地存储</h1>
    <ul>
        <li>
            <%= Html.ActionLink("常规 HTTP 请求", "regular_http_request", null, new { title = "常规 HTTP 请求" })%></li>
        <li>
            <%= Html.ActionLink("Ajax HTTP 请求", "ajax_http_request", null, new { title = "Ajax HTTP 请求" })%></li>
        <li>
            <%= Html.ActionLink("带有 Http 缓存的请求", "http_cache", null, new { title = "带有 Http 缓存的请求" })%></li>
        <li>
            <%= Html.ActionLink("带有 Html5 本地存储的请求", "html5_local_storage", null, new { title = "带有 Html5 本地存储的请求" })%></li>
    </ul>
</asp:Content>

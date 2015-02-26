<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Demo 示例</asp:Content>
<asp:Content ID="InHead" ContentPlaceHolderID="InHeadContent" runat="server"></asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="InPageContent" runat="server">
    <div class="large-page">
        <h2>我的一些 Demo 示例</h2>
        <div class="large-page-part">
            <p class="entry">
                <%= Html.ActionLink("制作 Google Chrome Extension 谷歌浏览器扩展", "Google_Chrome_Extension", "ClientCode",
                    null, new { title = "制作 Google Chrome Extension 谷歌浏览器扩展" })%></p>
            <p class="entry">
                <%= Html.ActionLink("简单的 Javascript 3D 标签云", "Javascript_Simple_3D_Tag_Cloud", "ClientCode",
                    null, new { title = "简单的 Javascript 3D 标签云" })%></p>
            <p class="entry">
                <%= Html.ActionLink("Http 缓存和 Html5 本地存储", "Index", "Http_Cache_And_Html5_Local_Storage", 
                    null, new { title = "Http 缓存和 Html5 本地存储" })%></p>
            <p class="entry">
                <%= Html.ActionLink("太平洋战争-时间线地图 Pacific War Timeline Map", "Pacific_War_Timeline_Map", "ClientCode",
                    null, new { title = "太平洋战争-时间线地图 Pacific War Timeline Map" })%></p>
            <p class="entry">
                <%= Html.ActionLink("Javascript Sanke Game 贪吃蛇游戏", "Javascript_Snake_Game", "ClientCode",
                    null, new { title = "Javascript Sanke Game 贪吃蛇游戏" })%></p>
        </div>
    </div>
</asp:Content>

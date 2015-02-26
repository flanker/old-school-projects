<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.AboutDTO>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">关于</asp:Content>
<asp:Content ID="InHead" ContentPlaceHolderID="InHeadContent" runat="server"></asp:Content>
<asp:Content ID="InPage" ContentPlaceHolderID="InPageContent" runat="server">
    <div class="smallPage">
        <h2>我的关键词：</h2>
        <div class="smallPagePart">
            <ul class="keywords">
            <% foreach (string tag in Model.Tags)
               { %>
               <li><%= tag %>;</li>
            <% } %>
            </ul>
            <div class="clear"></div>
        </div>
        <h2>关于超级无敌：</h2>
        <div class="smallPagePart">
            <p>超级无敌是一个很简单很小的网站。是冯智超的个人网站，主要用来分享我个人的一些小东西。</p>
            <p>超级无敌使用 <a href="http://www.asp.net/mvc" title="ASP.NET MVC 官方网站">ASP.NET MVC</a> 创建，运行于米国的虚拟主机上。</p>
            <p>由于我不会美工，从小到大上过的美术课成绩也不尽如人意，可以说是没有美感，而且也找不到合适的美工，所以超级无敌网站就只能这样子比较简陋了。</p>
        </div>
        <h2>其他说明：</h2>
        <div class="smallPagePart">
            <p>推荐使用 <a href="http://www.google.com/chrome" title="Google Chrome 浏览器">Google Chrome 浏览器</a></p>
            <p>个人精力及水平有限，暂时无法照顾到每一个浏览器。对于本站，使用 Google Chrome 浏览器浏览效果最佳。当然，别的浏览器也是很棒的，无论使用何种浏览器，推荐使用最新的版本。</p>
        </div>
    </div>
</asp:Content>

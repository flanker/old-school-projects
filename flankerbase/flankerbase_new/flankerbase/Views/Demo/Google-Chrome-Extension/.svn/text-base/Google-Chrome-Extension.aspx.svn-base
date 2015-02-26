<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Demo.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">人人网广告杀手：制作 Google Chrome Extension 谷歌浏览器扩展</asp:Content>
<asp:Content ID="DemoNavBlog" ContentPlaceHolderID="DemoNavBlogPlaceHolder" runat="server">
<p class="demo-Nav-Blog"><a href="http://blog.chaojiwudi.com/2011/01/making-google-chrome-extension-renren-ads-killer/" title="人人网广告杀手 — 制作 Google Chrome Extension 谷歌浏览器扩展 | 宇宙超级无敌 | 冯智超的博客">关于本 demo 的博客文章</a></p>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">制作 Google Chrome Extension 谷歌浏览器扩展</h1>
    <p>人人网广告杀手：一个简单的去除人人网广告的 Google Chrome 谷歌浏览器扩展</p>
    <p>下载地址：<a href="http://chaojiwudi.com/download/renrenAdsKiller.crx" title="人人网广告杀手">http://chaojiwudi.com/download/renrenAdsKiller.crx</a></p>
    <p>扩展比较简单，通过在 manifest.json 中注册 Content Script，使得 Chrome 浏览器在访问匹配 http://*.renren.com/* 的页面时加载执行 script.js 脚本。 script.js 脚本在 &lt;head&gt; 中添加一段自定义的 css，该 css 将匹配的广告元素全部置成 display: none。</p>
    <h2 class="titleLine">manifest.json 文件内容</h2>
    <pre>
    {
      "name": "人人网广告杀手",
      "version": "0.1",
      "description": "清除掉人人网网页上的一些广告。",
      "permissions": ["tabs", "http://*.renren.com/*"],
      "content_scripts": [ 
        { "js": ["script.js"], "matches": [ "http://*.renren.com/*" ] }
      ]
    }
    </pre>
    <h2 class="titleLine">script.js 文件内容</h2>
    <pre>
    (function() {
        var css = ' ';
        // 针对广告的 selector 隐藏显示
        css += ' #header-wide-banner { display: none !important } ';
        css += ' .sponsors { display: none !important } ';
        css += ' .wide-sponsors { display: none !important } ';
        css += ' .sales-poll { display: none !important } ';
        css += ' #webpager-ad-panel { display: none !important } ';
        css += ' .navigation .blank-holder { display: none !important } ';
        css += ' .downloadclient { display: none !important } ';
        css += ' .kfc-banner { display: none !important } ';

        var heads = document.getElementsByTagName("head");
        if (heads.length > 0) {
            var node = document.createElement("style");
            node.type = "text/css";
            node.appendChild(document.createTextNode(css));
            heads[0].appendChild(node);
        }
    })();
    </pre>
</asp:Content>


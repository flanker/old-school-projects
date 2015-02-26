<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Demo.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">javascript snake game 贪吃蛇游戏</asp:Content>
<asp:Content ID="InHeadAbove" ContentPlaceHolderID="InHeadAboveContent" runat="server">
    <style type="text/css">
        #snake table {
            border: solid 1px Black;
        }
        #snake td {
            height: 20px;
            width: 20px;
        }
        .snakeCell {
            background-color: Green;
        }
        .appleCell {
            background-color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server">
    <script src="/scripts/demo/javascript-snake-game/snake.js" type="text/javascript" language="JavaScript"> 
    </script>
    <script language="JavaScript" type="text/javascript">
        window.onload = function() {
            initSnake('snake');
        }
    </script>
</asp:Content>
<asp:Content ID="DemoNavBlog" ContentPlaceHolderID="DemoNavBlogPlaceHolder" runat="server">
    <p class="demo-Nav-Blog"><a href="http://blog.chaojiwudi.com/2010/09/javascript-snake-game/" title="Javascript Snake Game 贪吃蛇游戏 | 宇宙超级无敌 | 冯智超的博客">关于本 demo 的博客文章</a></p>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">Javascript Snake Game 贪吃蛇游戏</h1>
    <p>this is a small snake game using javascript. press <strong>up/down/left/right</strong> to control snake direction. press <strong>spacebar</strong> to pause the game. press <strong>R</strong> to restart game. see the javascript source code <a href="/scripts/demo/javascript-snake-game/snake.js">here</a>. tested in Chrome, Firefox 3, Internet Explorer 8. if you find and bug or problem, please let me know. flankerfc (at) gmail.com </p>
    <div>
    </div>
    <div id="snake">
    </div>
</asp:Content>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%= ViewData["Title"] %>
    </title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="flanker 冯智超" />
    <meta name="description" content="flanker base - 侧卫基地, 冯智超的个人网站" />
    <link href="/Content/Home/index.css" type="text/css" rel="Stylesheet" />
    <script src="/Content/jquery.min.js" type="text/javascript"></script>
    <script src="/Content/Home/jquery.easing.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            //Remove outline from links
            $("a").click(function() {
                $(this).blur();
            });
            //When mouse rolls over
            $("li").mouseover(function() {
                $(this).stop().animate({ height: '80px' }, { queue: false, duration: 600, easing: 'easeOutBounce' })
            });
            //When mouse is removed
            $("li").mouseout(function() {
                $(this).stop().animate({ height: '20px' }, { queue: false, duration: 600, easing: 'easeOutBounce' })
            });
        });
    </script>
</head>
<body>
    <div id="musicBox">
        <div id="beian">
            <a href="http://www.miibeian.gov.cn" target="_blank">京ICP备09020668号</a></div>
        <div id="music">
            <span>Michael Jackson - You Are Not Alone</span>
            <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                width="60" height="22" id="dewplayer" align="middle">
                <param name="wmode" value="transparent" />
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="movie" value="/Content/Home/dewplayer.swf?mp3=/Content/Home/youarenotalone.mp3&amp;autostart=1&amp;autoreplay=1" />
                <param name="quality" value="high" />
                <param name="bgcolor" value="FFFFFF" />
                <embed src="/Content/Home/dewplayer.swf?mp3=/Content/Home/youarenotalone.mp3&amp;autostart=1&amp;autoreplay=1"
                    quality="high" bgcolor="FFFFFF" width="60" height="22" name="dewplayer" wmode="transparent"
                    align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                    pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>
            </object>
        </div>
    </div>
    <div id="main">
        <%-- <img alt="换一种生活,换一份心情." src="Content/Home/change.png"  />--%>
        <div id="change" />
    </div>
    <div id="menu">
        <ul>
            <li class="c1">
                <p><a href="/">首页</a></p>
                <p>回到主基地</p>
            </li>
            <li class="c2">
                <p><a href="/Life.aspx/Index">生活</a></p>
                <p>我的生活很精彩</p>
            </li>
            <li class="c3">
                <p><a href="/Music.aspx/Index">音乐</a></p>
                <p>放松你的耳朵</p>
            </li>
            <li class="c4">
                <p><a href="/Movie.aspx/Index">影视</a></p>
                <p>电影, 电视剧</p>
            </li>
            <li class="c5">
                <p><a href="/Game.aspx/Index">游戏</a></p>
                <p>体会另一个自己</p>
            </li>
             <li class="c6">
                <p><a href="#">***</a></p>
                <p>*****</p>
            </li>
            <li class="c7">
                <p><a href="#">***</a></p>
                <p>*****</p>
            </li>
        </ul>
    </div>
</body>
</html>

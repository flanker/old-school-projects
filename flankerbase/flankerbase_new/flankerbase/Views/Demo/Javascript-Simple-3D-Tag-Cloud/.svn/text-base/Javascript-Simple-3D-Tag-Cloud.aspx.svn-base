<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Demo.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">简单的 javascript 3D Tag Cloud 标签云</asp:Content>
<asp:Content ID="InHeadAbove" ContentPlaceHolderID="InHeadAboveContent" runat="server">
    <style type="text/css">
        #tagCloud {
            height: 300px;
            width: 600px;
            background-color: #000;
            position: relative;
            margin: 0;
            overflow: hidden;
        }
        #tagCloud ul, #tagCloud li {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        #tagCloud a {
            position: absolute;
            text-decoration: none;
            color: #0B61A4;
            text-shadow: #66A3D2 1px -1px 1px;
        }
        #tagCloud a:hover {
            color: #66A3D2;
        }
        #setting {
            padding: 10px;
            border: solid 1px #000000;
            width: 578px;
        }
    </style>
</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server">
    <script type="text/javascript">
        // Js 标签云构造
        function JsTagCloud(config) {

            // 对应的 Div 标签
            var cloud = document.getElementById(config.CloudId);
            this._cloud = cloud;

            // w, h 是 Div 的高宽
            var w = parseInt(this._getStyle(cloud, 'width'));
            var h = parseInt(this._getStyle(cloud, 'height'));
            this.width = (w - 100) / 2;
            this.height = (h - 50) / 2;

            // 初始化
            this._items = cloud.getElementsByTagName('a');
            this._count = this._items.length;
            this._angle = 360 / (this._count);
            this._radian = this._angle * (2 * Math.PI / 360);
            this.step = 0;
        }

        // 获取对象 Style
        JsTagCloud.prototype._getStyle = function(elem, name) {
            return window.getComputedStyle ? window.getComputedStyle(elem, null)[name] : elem.currentStyle[name];
        }

        // 渲染标签云
        JsTagCloud.prototype._render = function() {

            for (var i = 0; i < this._count; i++) {
                var item = this._items[i];
                var thisRadian = (this._radian * i) + this.step;
                var sinV = Math.sin(thisRadian);
                var cosV = Math.cos(thisRadian);

                // 设置 CSS 内联样式
                item.style.left = (sinV * this.width) + this.width + 'px';
                item.style.top = this.height + (cosV * 50) + 'px';
                item.style.fontSize = cosV * 10 + 20 + 'pt';
                item.style.zIndex = cosV * 1000 + 2000;
                item.style.opacity = (cosV / 2.5) + 0.6;
                item.style.filter = " alpha(opacity=" + ((cosV / 2.5) + 0.6) * 100 + ")";
            }
            this.step += 0.007;
        }

        // 开始
        JsTagCloud.prototype.start = function() {

            setInterval(function(who) {
                return function() {
                    who._render();
                };
            } (this), 20);
        }

        window.onload = function() {
            var tagCloud = new JsTagCloud({ CloudId: 'tagCloud' });
            tagCloud.start();
        }
    </script>
</asp:Content>
<asp:Content ID="DemoNavBlog" ContentPlaceHolderID="DemoNavBlogPlaceHolder" runat="server">
<p class="demo-Nav-Blog"><a href="http://blog.chaojiwudi.com/2010/12/making-a-simple-javascript-3d-tag-cloud/" title="制作一个简单的 Javascript 3D Tag Cloud 旋转标签云 | 宇宙超级无敌 | 冯智超的博客">关于本 demo 的博客文章</a></p>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">简单的 javascript 3D Tag Cloud 标签云</h1>
    <div id="tagCloud">
        <ul>
            <li><a href="#">csharp</a></li>
            <li><a href="#">javascript</a></li>
            <li><a href="#">html</a></li>
            <li><a href="#">css</a></li>
            <li><a href="#">java</a></li>
            <li><a href="#">ruby</a></li>
            <li><a href="#">xml</a></li>
            <li><a href="#">jquery</a></li>
            <li><a href="#">php</a></li>
            <li><a href="#">python</a></li>
            <li><a href="#">linux</a></li>
            <li><a href="#">android</a></li>
            <li><a href="#">apple</a></li>
            <li><a href="#">google</a></li>
        </ul>
    </div>
    <%--    <div id="setting">
        <div>
            <label for="width">宽度: </label>
            <input id="width" value="600" />
        </div>
        <div>
            <label for="height">高度: </label>
            <input id="height" value="300" />
        </div>
        <div>
            <label for="interval">时间间隔: </label>
            <input id="interval" value="20" />
        </div>
        <div>
            <label for="step">步长: </label>
            <input id="step" value="0.007" />
        </div>
        <div>
            <input id="set" type="button" value="设置" onclick="onSetClick();" />
        </div>
    </div>--%>
    <p>在 Google Chrome 和 IE8 下测试过。</p>
    <h3 class="titleLine">CSS</h3>
    <pre>
        #tagCloud {
            height: 300px;
            width: 600px;
            background-color: #000;
            position: relative;
            margin: 0;
            overflow: hidden;
        }
        #tagCloud ul, #tagCloud li {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        #tagCloud a {
            position: absolute;
            text-decoration: none;
            color: #0B61A4;
            text-shadow: #66A3D2 1px -1px 1px;
        }
    </pre>
    <h3 class="titleLine">Javascript</h3>
    <pre>
        // Js 标签云构造
        function JsTagCloud(config) {

            // 对应的 Div 标签
            var cloud = document.getElementById(config.CloudId);
            this._cloud = cloud;

            // w, h 是 Div 的高宽
            var w = parseInt(this._getStyle(cloud, 'width'));
            var h = parseInt(this._getStyle(cloud, 'height'));
            this.width = (w - 100) / 2;
            this.height = (h - 50) / 2;

            // 初始化
            this._items = cloud.getElementsByTagName('a');
            this._count = this._items.length;
            this._angle = 360 / (this._count);
            this._radian = this._angle * (2 * Math.PI / 360);
            this.step = 0;
        }
        
        // 获取对象 Style
        JsTagCloud.prototype._getStyle = function(elem, name) {
            return window.getComputedStyle ? window.getComputedStyle(elem, null)[name] : elem.currentStyle[name];
        }

        // 渲染标签云
        JsTagCloud.prototype._render = function() {

            for (var i = 0; i < this._count; i++) {
                var item = this._items[i];
                var thisRadian = (this._radian * i) + this.step;
                var sinV = Math.sin(thisRadian);
                var cosV = Math.cos(thisRadian);

                // 设置 CSS 内联样式
                item.style.left = (sinV * this.width) + this.width + 'px';
                item.style.top = this.height + (cosV * 50) + 'px';
                item.style.fontSize = cosV * 10 + 20 + 'pt';
                item.style.zIndex = cosV * 1000 + 2000;
                item.style.opacity = (cosV / 2.5) + 0.6;
                item.style.filter = " alpha(opacity=" + ((cosV / 2.5) + 0.6) * 100 + ")";
            }
            this.step += 0.007;
        }

        // 开始
        JsTagCloud.prototype.start = function() {

            setInterval(function(who) {
                return function() {
                    who._render();
                };
            } (this), 20);
        }

        window.onload = function() {
            var tagCloud = new JsTagCloud({ CloudId: 'tagCloud' });
            tagCloud.start();
        }
    </pre>
</asp:Content>

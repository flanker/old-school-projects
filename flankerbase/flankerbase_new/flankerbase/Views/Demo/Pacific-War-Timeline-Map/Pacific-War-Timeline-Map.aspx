<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Demo.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">Pacific War Timeline Map 太平洋战争时间地图</asp:Content>
<asp:Content ID="InHeadAbove" ContentPlaceHolderID="InHeadAboveContent" runat="server">
<style type="text/css">
    #tl {
        width: 800px;
        height: 220px;
    }
    #map {
        width: 800px;
        height: 450px;
    }
    .infoContent {
        font-family: sans-serif;
        font-size: small;
        width: 300px;
    }
    .infoContent-title {
        font-size: medium;
        font-weight: bold;
    }
    .infoContent-label {
        font-weight: bold;
    }
    .infoContent-description {
        max-height: 100px;
        overflow: auto;
    }
    .infoContent-wiki a {
        color: #3366FF;
    }
</style>
</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="http://static.simile.mit.edu/timeline/api-2.3.0/timeline-api.js?bundle=true"></script>
    <script type="text/javascript" src="/scripts/demo/pacific-war-timeline-map/timemap.js"></script>
    <script type="text/javascript">
        window.onload = function() {
            var timelinemap = new Timemap({ timeId: 'tl', mapId: 'map' });
            timelinemap.loadJson('/scripts/demo/pacific-war-timeline-map/data_pacific_war.js');
        }    </script>
</asp:Content>
<asp:Content ID="DemoNavBlog" ContentPlaceHolderID="DemoNavBlogPlaceHolder" runat="server">
    <p class="demo-Nav-Blog"><a href="http://blog.chaojiwudi.com/2010/10/pacific_war_timeline_map/" title="太平洋战争-时间线地图 Pacific War Timeline Map | 宇宙超级无敌 | 冯智超的博客">关于本 demo 的博客文章</a></p>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">太平洋战争-时间线地图 Pacific War Timeline Map</h1>
    <div id="tl">
    </div>
    <div id="map">
    </div>
</asp:Content>

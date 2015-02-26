<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service</title>
    <link href="css.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <div id="header">
        <h1>Service</h1>
    </div>
    <div id="main">
        <div class="right">
            <div id="content">
                <h4>这是什么?</h4>
                <p>这是一个使用WCF/.NET 3.5建立的地图-时间轴服务.目前可以提供地震信息.</p>
                <h4>服务元数据</h4>
                <ul>
                    <li><a href="Earthquake.svc">Earthquake服务简介</a></li>
                    <li><a href="Earthquake.svc?wsdl">Earthquake服务WSDL</a></li>
                </ul>
                <h4>如何通过Web访问服务</h4>
                <p>本服务使用.NET 3.5中WCF新增的Web编程模型构建, 可以直接通过Web进行访问.</p>
                <p>数据来源:<a href="http://earthquake.usgs.gov" target="_blank">U.S. Geological Survey</a></p>
                <ul>
                    <li><a href="Earthquake.svc/GetEvents/week">本周地震信息</a></li>
                    <li><a href="Earthquake.svc/GetEvents/day">本日地震信息</a></li>
                </ul>
                <h4>怎样使用本服务</h4>
                <p>可以通过多种方式访问并使用本服务.下面是一个示例:</p>
                <p><a href="wenchuan/index.html">地震地图-时间轴展示</a></p>
            </div>
        </div>
    </div>
    <div id="footer">
        <div class="right">
            <p>flanker & szzz</p>
        </div>
    </div>
</body>
</html>

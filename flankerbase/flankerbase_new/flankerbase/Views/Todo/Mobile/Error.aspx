<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" ContentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Error</title>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link href="/CM/c.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <h1>Todo list</h1>
        <div id="menu">
            <%= Html.ActionLink("返回", "T") %>
        </div>
        <div id="main">
            <p>出错啦~~~</p>
            <p>真失败, 出错了...</p>
        </div>
    </div>
</body>
</html>

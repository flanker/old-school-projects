<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
    <link href="/CM/c.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <h1>Todo list</h1>
        <div id="menu">
            <%= Html.ActionLink("返回", "T") %>
        </div>
        <div id="main">
            <p>
                出错啦~~~</p>
            <p>
                真失败, 出错了...</p>
        </div>
    </div>
</body>
</html>

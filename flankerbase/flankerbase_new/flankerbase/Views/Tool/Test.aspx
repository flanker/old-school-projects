<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" ContentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Test</title>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
</head>
<body>
    <div>
        <%= Html.Encode(ViewData["r"].ToString()) %>
    </div>
</body>
</html>

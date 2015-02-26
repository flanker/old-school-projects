<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>CommonHttpRequest</title>
</head>
<body>
    <div>
    <h1><%= Html.Encode(ViewData["result"])%></h1>
    </div>
</body>
</html>

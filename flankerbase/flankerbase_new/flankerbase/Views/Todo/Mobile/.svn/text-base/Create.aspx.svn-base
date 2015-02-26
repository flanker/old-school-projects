<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.Todo>" ContentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Create</title>
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
            <% using (Html.BeginForm())
               { %>
            <%= Html.TextArea("Description", new { rows = 5, value = "小可爱" }) %>
            <br />
            <input id="add" type="submit" value="ADD+" />
            <% } %>
        </div>
    </div>
</body>
</html>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.Todo>" ContentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Finish</title>
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
            <p>确定这个任务完成? 完成了的任务将不能再修改.</p>
            <p>
                <%= Html.Encode(Model.Description) %></p>
            <% using (Html.BeginForm())
               { %>
            <input name="confirmButton" type="submit" value="确定" />
            <% } %>
        </div>
    </div>
</body>
</html>

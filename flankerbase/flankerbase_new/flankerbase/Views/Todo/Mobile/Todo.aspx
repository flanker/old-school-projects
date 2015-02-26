<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.TodoDTO>" ContentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Todo</title>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link href="/CM/c.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <div id="X">
            <%= Html.ActionLink("桌面版", "X", new { model = "D"}) %>
        </div>
        <h1>Todo list</h1>
        <div id="process">
            共计:
            <%= Model.Process.AllCount %>, 已完成:
            <%= Model.Process.AllFinishCount %>
        </div>
        <div id="menu">
            <%= Html.ActionLink("新建", "C") %>
        </div>
        <div id="main">
            <% foreach (var item in Model.Todos)
               { %>
            <div>
                <%= Html.Encode(item.Description) %>
                <% if (item.IsFinished)
                   { %>
                (已完成)
                <% } %>
                <% else
                    { %>
                <%= Html.ActionLink("[F]", "F", new { id = item.ID }) %>
                <%= Html.ActionLink("[X]", "D", new { id = item.ID }) %>
                <% } %>
            </div>
            <% } %>
        </div>
    </div>
</body>
</html>

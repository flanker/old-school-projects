<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.TodoDTO>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo</title>
    <link href="/CM/c.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <div id="X">
            <%= Html.ActionLink("桌面版", "X", new { model = "D"}) %>
        </div>
        <h1>Todo list</h1>
        <div id="process">
            共计: <%= Model.Process.AllCount %>, 已完成: <%= Model.Process.AllFinishCount %>
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
                (已完成) <% } %>
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

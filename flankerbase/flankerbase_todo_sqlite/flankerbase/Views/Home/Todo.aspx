<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase.Models.Todo>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo list</title>
    <link href="/Content/todo.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.corner.js" type="text/javascript"></script>
    <script src="/Scripts/todo.js" type="text/javascript"></script>
</head>
<body>
    <div id="main">
        <div id="wrapper">
            <div id="mainpic">
            </div>
            <div id="content">
                <div>
                    <h1>Todo list</h1>
                </div>
                <div>
                    <% using (Ajax.BeginForm(
                           new AjaxOptions()
                           {
                               InsertionMode = InsertionMode.InsertBefore,
                               UpdateTargetId = "todos",
                               OnBegin = "postBegin",
                               OnSuccess = "afterPostSuccess",
                               OnFailure = "afterPostFailure",
                           }))
                       { %>
                    <%= Html.TextArea("Description") %>
                    <input id="add" type="submit" value="ADD+" />
                    <% } %>
                </div>
                <div id="todos-wrapper" class="rounded">
                    <ul id="todos">
                        <% foreach (var item in Model)
                           { %>
                        <li><%= Html.Encode(item.Description) %>
                        </li>
                        <% } %>
                    </ul>
                </div>
            </div>
            <div id="footer">
                <p>
                    xiaoxifuer's todo list @ flankerbase</p>
            </div>
        </div>
    </div>
</body>
</html>

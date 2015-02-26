<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.TodoDTO>"
    ContentType="text/html; charset=UTF-8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo list</title>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link href="/Content/todo.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/todo.js" type="text/javascript" charset="UTF-8"></script>
</head>
<body>
    <div id="main">
        <div id="wrapper">
            <div id="mainpic">
                <div id="X">
                    <%= Html.ActionLink("手机版", "X", new { model = "M"}) %></div>
            </div>
            <div id="content">
                <div id="title">
                    <h1>Xiaoxifuer's Todo List</h1>
                </div>
                <div id="form">
                    <% using (Ajax.BeginForm("Create",
                           new AjaxOptions()
                           {
                               InsertionMode = InsertionMode.Replace,
                               UpdateTargetId = "todos-content",
                               OnBegin = "postBegin",
                               OnComplete = "postComplete",
                               OnSuccess = "afterPostSuccess",
                               OnFailure = "ajaxFailure",
                           }))
                       { %>
                    <%= Html.TextArea("Description") %>
                    <div>
                        <input id="add" type="submit" value="ADD+" />
                    </div>
                    <% } %>
                    <div id="overlayer">
                    </div>
                </div>
                <div id="todos-content">
                    <% Html.RenderPartial("todos", Model); %>
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

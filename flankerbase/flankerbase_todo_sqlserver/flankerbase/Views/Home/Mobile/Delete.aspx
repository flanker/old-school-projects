<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.Todo>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete</title>
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
                确定要销毁罪证?</p>
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

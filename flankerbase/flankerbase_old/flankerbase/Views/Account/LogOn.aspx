<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LogOn</title>
</head>
<body>
    <h2>登录</h2>
    <p>请输入你的用户名和密码。</p>
    <%= Html.ValidationSummary("登录失败。请修改错误并重试。") %>
    <% using (Html.BeginForm())
       { %>
    <div>
        <fieldset><legend>账户信息</legend>
            <p>
                <label for="username">用户名：</label>
                <%= Html.TextBox("username") %>
                <%= Html.ValidationMessage("username") %>
            </p>
            <p>
                <label for="password">密码：</label>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password") %>
            </p>
            <p>
                <input type="submit" value="登录" />
            </p>
        </fieldset>
    </div>
    <% } %>
</body>
</html>

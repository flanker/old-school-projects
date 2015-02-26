<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    登录
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>登录</h2>
    <p>请输入你的用户名和密码。如果没有账户，请
        <%= Html.ActionLink("注册", "Register") %></p>
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
                <%= Html.CheckBox("rememberMe") %>
                <label class="inline" for="rememberMe">记住我？</label>
            </p>
            <p>
                <input type="submit" value="登录" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>

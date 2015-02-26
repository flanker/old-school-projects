<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    注册用户
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>创建新账户</h2>
    <p>使用下面的表格来创建一个新的账户。</p>
    <p>密码不能少于
        <%=Html.Encode(ViewData["PasswordLength"])%>
        个字符。</p>
    <%= Html.ValidationSummary("账户创建失败。请修改错误并重试。")%>
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
                <label for="email">电子邮件：</label>
                <%= Html.TextBox("email") %>
                <%= Html.ValidationMessage("email") %>
            </p>
            <p>
                <label for="password">密码：</label>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password") %>
            </p>
            <p>
                <label for="confirmPassword">密码确认：</label>
                <%= Html.Password("confirmPassword") %>
                <%= Html.ValidationMessage("confirmPassword") %>
            </p>
            <p>
                <input type="submit" value="注册" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>

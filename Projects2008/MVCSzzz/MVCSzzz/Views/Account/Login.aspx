<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">登录 </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h2>请登录</h2>
    <p>请输入你的用户名和密码:</p>
    <%= Html.ValidationSummary() %>
    <% using (Html.BeginForm())
       {
    %>
    <fieldset>
        <p>
            <label for="username">用户</label>
            <%=Html.TextBox("username") %>
            <%= Html.ValidationMessage("username") %></p>
        <p>
            <label for="password">密码</label>
            <%=Html.Password("password") %>
            <%=Html.ValidationMessage("password") %></p>
        <p>
            <input type="submit" value="确定" />
            <input type="reset" value="重置" />
        </p>
    </fieldset>
    <%
        } %>
</asp:Content>

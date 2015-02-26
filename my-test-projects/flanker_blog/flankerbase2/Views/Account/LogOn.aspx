<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    flanker base - log on
</asp:Content>
<asp:Content ID="loginScript" ContentPlaceHolderID="HeadContent" runat="server">
    <% Html.RenderPartial("FormFocus"); %>
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-box-wrap">
        <div class="content-box">
            <p>
                <%= Strings.please_enter_your_name_and_password %></p>
            <%= Html.ValidationSummary(Strings.login_was_unsuccessful) %>
            <% using (Html.BeginForm())
               { %>
            <p>
                <label for="username">
                    <%= Strings.username %></label>
                <%= Html.TextBox("username") %>
                <%= Html.ValidationMessage("username", "*") %>
            </p>
            <p>
                <label for="password">
                    <%= Strings.password %></label>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password", "*") %>
            </p>
            <p>
                <%= Html.CheckBox("rememberMe") %>
                <label class="inline" for="rememberMe">
                    <%= Strings.remember_me %></label>
            </p>
            <p>
                <input type="submit" value="<%= Strings.logon %>" />
            </p>
            <% } %>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">��¼ </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h2>���¼</h2>
    <p>����������û���������:</p>
    <%= Html.ValidationSummary() %>
    <% using (Html.BeginForm())
       {
    %>
    <fieldset>
        <p>
            <label for="username">�û�</label>
            <%=Html.TextBox("username") %>
            <%= Html.ValidationMessage("username") %></p>
        <p>
            <label for="password">����</label>
            <%=Html.Password("password") %>
            <%=Html.ValidationMessage("password") %></p>
        <p>
            <input type="submit" value="ȷ��" />
            <input type="reset" value="����" />
        </p>
    </fieldset>
    <%
        } %>
</asp:Content>

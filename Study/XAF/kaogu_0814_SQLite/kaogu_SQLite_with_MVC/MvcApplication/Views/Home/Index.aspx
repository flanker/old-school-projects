<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<kaogu_0730.Module.Project>>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add a new project</h2>
    <%
        Html.BeginForm(); %>
    <label>Name:</label><%= Html.TextBox("projectName") %>
    <input type="submit" value="Add" />
    <%
       Html.EndForm(); %>
    <h2>List of all projects:</h2>
    <ul>
    <%
        foreach (var project in Model)
        {
    %>
        <li><%= project.Name %></li>
    <%
        }
    %>
    </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.Together>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    ËÑË÷
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>¸ß¼¶ËÑË÷</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <p>
        <label for="Title">Title:</label>
        <%= Html.TextBox("Title") %>
        <%= Html.ValidationMessage("Title", "*") %>
    </p>
    <p>
        <label for="UserName">UserName:</label>
        <%= Html.TextBox("UserName") %>
        <%= Html.ValidationMessage("UserName", "*") %>
    </p>
    <p>
        <label for="Address">Address:</label>
        <%= Html.TextBox("Address") %>
        <%= Html.ValidationMessage("Address", "*") %>
    </p>
    <p>
        <label for="StartDate">StartDate:</label>
        <%= Html.TextBox("StartDate") %>
        <%= Html.ValidationMessage("StartDate", "*") %>
    </p>
    <p>
        <label for="Description">Description:</label>
        <%= Html.TextBox("Description") %>
        <%= Html.ValidationMessage("Description", "*") %>
    </p>
    <p>
        <label for="Fee">Fee:</label>
        <%= Html.TextBox("Fee") %>
        <%= Html.ValidationMessage("Fee", "*") %>
    </p>
    <p>
        <label for="ContactPhone">ContactPhone:</label>
        <%= Html.TextBox("ContactPhone") %>
        <%= Html.ValidationMessage("ContactPhone", "*") %>
    </p>
    <p>
        <input type="submit" value="ËÑË÷" />
    </p>
    <% } %>
</asp:Content>

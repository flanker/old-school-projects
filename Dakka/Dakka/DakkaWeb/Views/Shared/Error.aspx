<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="DakkaWeb.Views.Shared.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sorry, an error occurred while processing your request. </h1>
    <p><%= ViewData["ErrorMessage"] %></p>
</asp:Content>

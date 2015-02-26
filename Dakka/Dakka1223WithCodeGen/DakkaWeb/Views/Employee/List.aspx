<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="DakkaWeb.Views.Employee.List" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContend" runat="server">

    <script src="../../Scripts/Employee/List.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="gridAll">
    </div>
    <div id="windowNew">
    </div>
    <div id="windowEdit">
    </div>
</asp:Content>

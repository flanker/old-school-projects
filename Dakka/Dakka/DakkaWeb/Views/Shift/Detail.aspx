<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="DakkaWeb.Views.Shift.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
    var processID = <%= Html.Encode(ViewData["ID"])%>;
    </script>

    <script src="../../Scripts/Shift/Detail.js" type="text/javascript"></script>

    <div id="divMain">
    </div>
    <div id="rightClickCont">
    </div>
</asp:Content>

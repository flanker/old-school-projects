<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-box-wrap">
        <div class="content-box">
            <h2>Sorry, an error occurred while processing your request. </h2>
            <%= Model.Exception.ToString() %>
        </div>
    </div>
</asp:Content>

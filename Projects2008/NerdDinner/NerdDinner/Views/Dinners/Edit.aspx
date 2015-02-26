<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<NerdDinner.Models.DinnerFormViewModel>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Edit:
    <%= Html.Encode(Model.Dinner.Title)%>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Dinner</h2>
    <% Html.RenderPartial("DinnerForm"); %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

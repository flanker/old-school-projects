<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.TogetherFormViewModel>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    �޸ģ�
    <%= Html.Encode(Model.Together.Title)%>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>�޸Ļ</h2>
    <% Html.RenderPartial("TogetherForm"); %>
    <div>
        <%=Html.ActionLink("�����б�", "Index") %>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Helper.PaginatedList<HappyTogether.Models.Together>>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    ��б�
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>��б�</h2>
    <% Html.RenderPartial("TogetherListPager"); %>
    <% Html.RenderPartial("TogetherList"); %>
    <% Html.RenderPartial("TogetherListPager"); %>
</asp:Content>

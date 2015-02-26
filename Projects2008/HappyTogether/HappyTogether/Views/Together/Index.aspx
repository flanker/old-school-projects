<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Helper.PaginatedList<HappyTogether.Models.Together>>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    活动列表
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>活动列表</h2>
    <% Html.RenderPartial("TogetherListPager"); %>
    <% Html.RenderPartial("TogetherList"); %>
    <% Html.RenderPartial("TogetherListPager"); %>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.TogetherFormViewModel>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    修改：
    <%= Html.Encode(Model.Together.Title)%>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>修改活动</h2>
    <% Html.RenderPartial("TogetherForm"); %>
    <div>
        <%=Html.ActionLink("返回列表", "Index") %>
    </div>
</asp:Content>

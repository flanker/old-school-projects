<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.Together>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    删除：
    <%= Html.Encode(Model.Title) %>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>删除确认</h2>
    <div>
        <p>请确认你要删除名称为<i>
            <%=Html.Encode(Model.Title) %></i> 的活动？</p>
    </div>
    <% using (Html.BeginForm())
       { %>
    <input name="confirmButton" type="submit" value="删除" />
    <% } %>
</asp:Content>

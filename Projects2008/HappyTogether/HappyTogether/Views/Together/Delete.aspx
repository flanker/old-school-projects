<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.Together>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    ɾ����
    <%= Html.Encode(Model.Title) %>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ɾ��ȷ��</h2>
    <div>
        <p>��ȷ����Ҫɾ������Ϊ<i>
            <%=Html.Encode(Model.Title) %></i> �Ļ��</p>
    </div>
    <% using (Html.BeginForm())
       { %>
    <input name="confirmButton" type="submit" value="ɾ��" />
    <% } %>
</asp:Content>

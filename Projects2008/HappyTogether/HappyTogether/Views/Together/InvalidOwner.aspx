<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    错误</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>访问活动错误</h2>
    <p>Sorry，只有活动的创建者才能修改或者删除该活动。</p>
</asp:Content>

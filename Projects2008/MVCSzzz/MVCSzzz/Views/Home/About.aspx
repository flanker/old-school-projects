<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">我的档案</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h2>我的档案</h2>
    <p>这个页面只有登录用户才有权限访问!</p>
</asp:Content>

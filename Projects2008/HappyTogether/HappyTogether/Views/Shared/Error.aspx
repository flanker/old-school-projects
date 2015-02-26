<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    错误
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sorry，在处理请求时发生错误。</h2>
    <p><b>错误信息：</b></p>
    <p>在处理Controller<i><%= Model.ControllerName %></i>的Action<i><%= Model.ActionName %></i>遇到异常<i><%=Model.Exception.Message %></i></p>
    <p><b>堆栈信息：</b></p>
    <p><%= Model.Exception.StackTrace %></p>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Http_Cache_And_Html5_Local_Storage/Http_Cache_And_Html5_Local_Storage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">常规 HTTP 请求</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server"></asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">常规 Http 请求</h1>
    <p>demo - Http 缓存和 Html5 本地存储</p>
    <h2>运行结果： <span id="result">
        <%= Html.Encode(ViewData["result"])%></span></h2>
    
    <h3 class="titleLine">本页面使用常规 HTTP 请求，具体过程如下：</h3>
    <ol>
        <li>客户端发送 HTTP 请求 /Reqular_Http_Request </li>
        <li>服务器端接收到请求</li>
        <li>服务器端处理数据（耗时5秒）</li>
        <li>服务器端返回响应</li>
        <li>客户端接收响应</li>
        <li>客户端显示结果</li>
    </ol>
    <h3 class="titleLine">服务器端代码</h3>
    <pre>
    Result Regular_Http_Request() {
        result = GetDateTimeNow();
        Sleep(5000);
        return result;
    }    
        </pre>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Http_Cache_And_Html5_Local_Storage/Http_Cache_And_Html5_Local_Storage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">带有 Http 缓存的请求</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('#result').load('Ajax_Get_Result_With_Cache');
        });
    </script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">带有 Http 缓存的请求</h1>
    <p>demo - Http 缓存和 Html5 本地存储</p>
    <h2>运行结果： <span id="result">加载中...</span></h2>
    <p>注：10秒之内刷新，服务器不会返回新的结果</p>
    <h3 class="titleLine">本页面使用异步 Ajax Http 请求，但使用了 Http 缓存，具体过程如下：</h3>
    <ol>
        <li>客户端发送 HTTP 请求 /Http_Cache </li>
        <li>服务器端接收到请求、返回响应</li>
        <li>客户端接收响应、显示页面</li>
        <li>客户端发送 Ajax 请求数据 /Ajax_Get_Result_With_Cache</li>
        <li>服务器端接收请求
            <ul>
                <li>如果客户端缓存未过期，则<strong>返回 304 Not Modified</strong></li>
                <li>如果客户端缓存失效，则处理数据（5秒），返回结果</li>
            </ul>
        </li>
        <li>客户端显示结果，并更新缓存</li>
    </ol>
    <h3 class="titleLine">服务器端代码</h3>
    <pre>
    Result Http_Cache() {
        return page;
    }  
    
    Result Ajax_Get_Result_With_Cache() {
        if (IsValid(Request.Headers.If-Modified-Since)) {
            Response = "304 Not Modified";
            return;
        } else {
            result = GetDateTimeNow();
            Sleep(5000);
            return result;
        }
    }    
        </pre>
    <h3 class="titleLine">客户端代码</h3>
    <pre>
    $(document).ready(function() {
        $('#result').load('Ajax_Get_Result_With_Cache');
    });   
        </pre>
</asp:Content>

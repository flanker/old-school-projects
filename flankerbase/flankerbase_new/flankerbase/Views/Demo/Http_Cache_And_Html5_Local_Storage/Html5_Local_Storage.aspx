<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Demo/Http_Cache_And_Html5_Local_Storage/Http_Cache_And_Html5_Local_Storage.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">带有 Html5 本地存储的请求</asp:Content>
<asp:Content ID="InHeadBelow" ContentPlaceHolderID="InHeadBelowContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            if (window.localStorage) {
                var result = localStorage.getItem('result');
                if (result) {
                    $('#result').text(result);
                }
            }

            $.get('Ajax_Html5_Local_Storage', function(data) {
                $('#result').text(data);
                if (window.localStorage) {
                    localStorage.setItem('result', data);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="titleLine">带有 Html5 本地存储的请求</h1>
    <p>demo - Http 缓存和 Html5 本地存储</p>
    <h2>运行结果： <span id="result">加载中...</span></h2>
    <h3 class="titleLine">本页面使用使用了 Html5 本地存储，具体过程如下：</h3>
    <ol>
        <li>客户端发送 HTTP 请求 /Html5_Local_Storage</li>
        <li>服务器端接收到请求、返回响应</li>
        <li>客户端接收响应、显示页面，<strong>先从本地存储中加载数据显示</strong></li>
        <li>客户端发送 Ajax 请求数据 /Ajax_Html5_Local_Storage</li>
        <li>服务器端接收请求，处理数据（5秒），返回结果</li>
        <li>客户端显示结果，并更新本地存储</li>
    </ol>
    <h3 class="titleLine">服务器端代码</h3>
    <pre>
    Result Html5_Local_Storage() {
        return page;
    }  
    
    Result Ajax_Html5_Local_Storage() {
        result = GetDateTimeNow();
        Sleep(5000);
        return result;
    }    
        </pre>
    <h3 class="titleLine">客户端代码</h3>
    <pre>
    $(document).ready(function() {
        if (window.localStorage) {
            var result = localStorage.getItem('result');
            if (result) {
                $('#result').text(result);
            }
        }
        $.get('Ajax_Html5_Local_Storage', function(data) {
            $('#result').text(data);
            if (window.localStorage) {  
                localStorage.setItem('result', data);
            }
        });
    });   
        </pre>
</asp:Content>

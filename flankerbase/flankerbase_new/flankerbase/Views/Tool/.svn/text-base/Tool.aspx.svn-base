<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase.Models.ToolDTO>>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">我的常用工具</asp:Content>
<asp:Content ID="InHead" ContentPlaceHolderID="InHeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            $('#toollist').load('tool/ajaxcontent');
        });
    </script>
</asp:Content>
<asp:Content ID="InPage" ContentPlaceHolderID="InPageContent" runat="server">
    <div class="large-page">
        <h2>我的常用工具</h2>
        <p>常用的一些工具, 记录在这里.</p>
        <div class="large-page-part">
            <div id="toollist">
                <h1>加载中...</h1>
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

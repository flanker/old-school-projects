<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.TogetherFormViewModel>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    新建活动
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Scripts/jquery-ui-1.7.1.datepicker.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $("input.datepicker").datepicker({ showOn: 'button', buttonImage: '/Content/jQuery/images/calendar.gif', buttonImageOnly: true });
            $("input.datepicker").datepicker('option', $.datepicker.regional['zh-CN']);
            $("input.datepicker").datepicker('option', 'dateFormat', 'yy/mm/dd');
        });
    </script>
    <link href="/Content/jQuery/jquery.ui.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>创建一个活动</h2>
    <% Html.RenderPartial("TogetherForm"); %>
</asp:Content>

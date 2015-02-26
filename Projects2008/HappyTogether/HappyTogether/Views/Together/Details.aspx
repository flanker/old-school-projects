<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HappyTogether.Models.Together>" %>

<%@ Import Namespace="HappyTogether.Helper" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    详细：
    <%= Html.Encode(Model.Title) %>
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Scripts/jquery.corner.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AnimateAttendeeMessage() {
            $("#attendeemsg").animate({ fontSize: "1.5em" }, 500);
        }
        $(document).ready(function() {
            $('.rounded').corner();
        });
    </script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div id="togetherDiv">
        <p>
            <%= Html.ImageEncode(Model.PicURL, Model.Title) %>
        </p>
        <h2>
            <%= Html.Encode(Model.Title) %></h2>
        <% Html.RenderPartial("EditAndDeleteLink"); %>
        <p><strong>时间：</strong>
            <%= Model.StartDate.ToShortDateString() %>
            <strong>@</strong>
            <%= Model.StartDate.ToShortTimeString()%>
        </p>
        <p><strong>地点：</strong>
            <%= Html.Encode(Model.Address) %>
        </p>
        <p><strong>类型：</strong>
            <%= Html.Encode(Model.TogetherTypeString) %>
        </p>
        <p><strong>描述：</strong>
            <%= Html.Encode(Model.Description) %>
        </p>
        <p><strong>组织者：</strong>
            <%= Html.Encode(Model.UserName) %>
        </p>
        <p><strong>联系电话：</strong>
            <%= Html.Encode(Model.ContactPhone) %>
        </p>
        <p><strong>费用类型：</strong>
            <%= Html.Encode(Model.FeeTypeString) %>
        </p>
        <p><strong>费用说明：</strong>
            <%= Html.Encode(Model.Fee) %>
        </p>
    </div>
    <div id="mapDiv">
        <% Html.RenderPartial("map"); %>
    </div>
    <div class="clear">
    </div>
    <div id="attendeeDiv" class="clear rounded">
        <% Html.RenderPartial("Attendee"); %>
        <% Html.RenderPartial("AttendeeList", Model.Attendees); %>
    </div>
    <div id="postDiv" class="rounded">
        <% Html.RenderPartial("PostForm", ViewData["PostForm"]); %>
        <% Html.RenderPartial("PostList", Model.Posts); %>
    </div>
</asp:Content>

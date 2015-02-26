<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NerdDinner.Models.Dinner>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">Details:
    <%= Html.Encode(Model.Title) %>
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">

    <script type="text/javascript">
        function AnimateRSVPMessage() {
            $("#rsvpmsg").animate({ fontSize: "1.5em" }, 500);
        }
    </script>

</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dinnerDiv">
        <h2>
            <%= Html.Encode(Model.Title) %></h2>
        <p><strong>when:</strong>
            <%= Model.EventDate.ToShortDateString() %>
            <strong>@</strong>
            <%= Model.EventDate.ToShortTimeString() %>
        </p>
        <p><strong>Where:</strong>
            <%= Html.Encode(Model.Address) %>,
            <%= Html.Encode(Model.Country) %>
        </p>
        <p><strong>Description:</strong>
            <%= Html.Encode(Model.Description) %>
        </p>
        <p><strong>Organizer:</strong>
            <%= Html.Encode(Model.HostedBy) %>
            (<%= Html.Encode(Model.ContactPhone) %>)</p>
        <% Html.RenderPartial("RSVP"); %>
        <% Html.RenderPartial("EditAndDeleteLink"); %>
    </div>
    <div id="mapDiv">
        <% Html.RenderPartial("map"); %>
    </div>
</asp:Content>

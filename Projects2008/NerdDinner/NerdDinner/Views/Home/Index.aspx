﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">

    <script src="http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2" type="text/javascript"></script>

    <script src="../../Scripts/Map.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            LoadMap();
        });
        $(document).ready(function() {
            $("#search").click(function(evt) {
                var where = jQuery.trim($("#Location").val());
                if (where.length < 1)
                    return;
                FindDinnersGivenLocation(where);
            });
        });
        function FindDinnersGivenLocation(where) {
            map.Find("", where, null, null, null, null, null, false, null, null, callbackUpdateMapDinners);
        }
        function callbackUpdateMapDinners(layer, resultsArray, places, hasMore, VEErrorMessage) {
            $("#dinnerList").empty();
            clearMap();
            var center = map.GetCenter();
            $.post("/Search/SearchByLocation", { latitude: center.Latitude, longitude: center.Longitude },
                    function(dinners) {
                        $.each(dinners, function(i, dinner) {
                            var LL = new VELatLong(dinner.Latitude, dinner.Longitude, 0, null);
                            var RsvpMessage = "";
                            if (dinner.RSVPCount == 1)
                                RsvpMessage = "" + dinner.RSVPCount + " RSVP";
                            else
                                RsvpMessage = "" + dinner.RSVPCount + " RSVPs";
                            // Add Pin to Map
                            LoadPin(LL, '<a href="/Dinners/Details/' + dinner.DinnerID + '">' + dinner.Title + '</a>', "<p>" + dinner.Description + "</p>" + RsvpMessage);
                            //Add a dinner to the <ul> dinnerList on the right
                            $('#dinnerList').append($('<li/>').attr("class", "dinnerItem").append($('<a/>').attr("href", "/Dinners/Details/" + dinner.DinnerID).html(dinner.Title)).append(" (" + RsvpMessage + ")"));
                        });
                        // Adjust zoom to display all the pins we just added.
                        if (points.length > 1) {
                            map.SetMapView(points);
                        }
                        // Display the event's pin-bubble on hover.
                        $(".dinnerItem").each(function(i, dinner) {
                            $(dinner).hover(
                                function() { map.ShowInfoBox(shapes[i]); },
                                function() { map.HideInfoBox(shapes[i]); }
                            );
                        });
                    }, "json");
        }
    </script>

</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Find a Dinner</h2>
    <div id="mapDivLeft">
        <div id="searchBox">
            Enter your location:
            <%= Html.TextBox("Location") %>
            <input id="search" type="submit" value="Search" />
        </div>
        <div id="theMap">
        </div>
    </div>
    <div id="mapDivRight">
        <div id="dinnerList">
        </div>
    </div>
</asp:Content>

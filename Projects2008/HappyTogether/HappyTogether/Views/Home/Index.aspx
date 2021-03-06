﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.SelectList>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    HappyTogether
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="http://dev.ditu.live.com/mapcontrol/mapcontrol.ashx?v=6.1" type="text/javascript"></script>
    <script src="../../Scripts/Map.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.corner.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            LoadMap();
        });
        $(document).ready(function() {
            $("#search").click(function(evt) {
                var where = jQuery.trim($("#Location").val());
                if (where.length < 1)
                    return;
                FindTogethersGivenLocation(where);
            });
        });
        function FindTogethersGivenLocation(where) {
            $('#loading').show();
            map.Find("", where, null, null, null, null, null, false, null, null, callbackUpdateMapTogethers);
        }
        function callbackUpdateMapTogethers(layer, resultsArray, places, hasMore, VEErrorMessage) {
            $("#resultList ul").empty();
            clearMap();
            var center = map.GetCenter();
            var togetherType = $('#TogetherType').val();
            $.post("/Search/SearchByLocation", { latitude: center.Latitude, longitude: center.Longitude, togetherType: togetherType },
                    function(togethers) {
                        $.each(togethers, function(i, together) {
                            var LL = new VELatLong(together.Latitude, together.Longitude);
                            var AttendeeMessage = "";
                            if (together.AttendeeCount == 1)
                                AttendeeMessage = "" + together.AttendeeCount + " 个参与者";
                            else
                                AttendeeMessage = "" + together.AttendeeCount + " 个参与者";
                            // Add Pin to Map
                            LoadPin(LL, '<a href="/Together/Details/' + together.TogetherID + '">' + together.Title + '</a>',
                                "<p>组织者: " + together.UserName + "</p>"
                                + "<p>活动类型: " + together.TogetherType + "</p>"
                                + "<p>活动时间: " + together.StartDate + "</p>"
                                + "<p>活动地点: " + together.Address + "</p>"
                                + "<p>" + together.Description + "</p>" + AttendeeMessage);
                            //Add a together to the <ul> resultList on the right
                            $('#resultList ul').append($('<li/>').attr("class", "resultItem")
                                .append($('<span/>').addClass('thumb')
                                    .append($('<img/>').attr("src", together.PicURL).attr("alt", together.Title)))
                                .append(' ')
                                .append($('<span/>').addClass('result-body')
                                    .append($('<span/>')
                                        .append($('<a/>').attr('href', '/Together/Details/' + together.TogetherID).text(together.Title)))
                                    .append($('<span/>').text(AttendeeMessage))));
                        });
                        // Adjust zoom to display all the pins we just added.
                        if (points.length > 1) {
                            map.SetMapView(points);
                        }
                        // Display the event's pin-bubble on hover.
                        $(".resultItem").each(function(i, together) {
                            $(together).hover(
                                function() { map.ShowInfoBox(shapes[i]); },
                                function() { map.HideInfoBox(shapes[i]); }
                            );
                        });
                        $('#loading').hide();
                    }, "json");
        }
        // ------------------------------------------------------------
        $(document).ready(function() {
            $("#hotwords span").click(function() {
                $("#Location").val($(this).text());
                FindTogethersGivenLocation($(this).text());
            });
            $("#hotwords span").hover(function() {
                $(this).addClass("hover");
            }, function() {
                $(this).removeClass("hover");
            });
        });
        // ------------------------------------------------------------
        $(document).ready(function() {
            $(".rounded").corner();
        });
    </script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>创建快乐, 分享快乐</h2>
    <div id="mapDivLeft">
        <div id="searchBox">
            在 <%= Html.TextBox("Location") %>
            找 <%= Html.DropDownList("TogetherType", Model) %>
            <input id="search" type="submit" value="查找" />
        </div>
        <div id="hotwords">
            试试搜索
            <span>北京市</span>
            <span>西安市</span>
        </div>
        <div id="theMap" class="map">
        </div>
    </div>
    <div id="mapDivRight" class="rounded">
        <div id="resultList">
            <ul></ul>
            <img id="loading" src="/Content/Images/loading.gif" alt="载入中..." />
        </div>
    </div>
</asp:Content>

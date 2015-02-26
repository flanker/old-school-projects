<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.Together>" %>
<script src="http://dev.ditu.live.com/mapcontrol/mapcontrol.ashx?v=6.1" type="text/javascript"></script>
<script src="/Scripts/Map.js" type="text/javascript"></script>
<div id="theMap" class="map">
</div>
<script type="text/javascript">
    $(document).ready(function() {
        var latitude = <%= Model.Latitude %>;
        var longitude = <%= Model.Longitude %>;
        if ((latitude == 0) || (longitude == 0))
            LoadMap();
        else
            LoadMap(latitude, longitude, mapLoaded);
    });
    
    function mapLoaded() {
        var title = "<%= Html.Encode(Model.Title) %>";
        var address = "<%= Html.Encode(Model.Address) %>";
        LoadPin(center, title, address);
        map.SetZoomLevel(14);
    }
</script>

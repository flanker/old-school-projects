/// <reference path="jquery-1.3.2-vsdoc2.js" />

$(document).ready(function() {

    var geocoder = new GClientGeocoder();

    var map = new GMap2(document.getElementById("map_canvas"));

    map.enableScrollWheelZoom();

    map.addControl(new GLargeMapControl3D());

    map.setMapType(G_SATELLITE_MAP);

    map.setCenter(new GLatLng(39.91289633555756, 116.39654159545898), 13);

    var clickedPoint = null;

    var clickedMarker = null;

    var mgr = null;

    // 页面处理 =================================================================

    $("input[name='map_type']").click(function() {
        if ($("input[name='map_type']:checked").val() == 'normal_map')
            map.setMapType(G_NORMAL_MAP);
        else if ($("input[name='map_type']:checked").val() == 'satellite_map')
            map.setMapType(G_SATELLITE_MAP);
        else
            map.setMapType(G_HYBRID_MAP);
    });

    $('#btnPanLeft').click(function() {
        var center = map.getCenter();
        map.panTo(new GLatLng(center.lat(), center.lng() - 0.05));
    });
    $('#btnPanRight').click(function() {
        var center = map.getCenter();
        map.panTo(new GLatLng(center.lat(), center.lng() + 0.05));
    });
    $('#btnPanUp').click(function() {
        var center = map.getCenter();
        map.panTo(new GLatLng(center.lat() + 0.05, center.lng()));
    });
    $('#btnPanDown').click(function() {
        var center = map.getCenter();
        map.panTo(new GLatLng(center.lat() - 0.05, center.lng()));
    });

    $('#btnZoomIn').click(function() {
        map.zoomIn();
    });
    $('#btnZoomOut').click(function() {
        map.zoomOut();
    });

    $('#btnGetLngLat').click(function() {
        var center = map.getCenter();
        $('#lng').val(center.lng());
        $('#lat').val(center.lat());
    });

    $('#btnSetLngLat').click(function() {
        map.setCenter(new GLatLng($('#lat').val(), $('#lng').val()));
    });

    $('#btnGetAddress').click(function() {
        geocoder.getLocations(map.getCenter(), function(response) {
            map.clearOverlays();
            if (!response || response.Status.code != 200) {
                alert("Status Code:" + response.Status.code);
            } else {
                place = response.Placemark[0];
                $('#address').val(place.address);

                point = new GLatLng(place.Point.coordinates[1], place.Point.coordinates[0]);
                marker = new GMarker(point);
                map.addOverlay(marker);
                marker.openInfoWindowHtml(
        '<b>orig latlng:</b>' + response.name + '<br/>' +
        '<b>latlng:</b>' + place.Point.coordinates[0] + "," + place.Point.coordinates[1] + '<br>' +
        '<b>Status Code:</b>' + response.Status.code + '<br>' +
        '<b>Status Request:</b>' + response.Status.request + '<br>' +
        '<b>Address:</b>' + place.address + '<br>' +
        '<b>Accuracy:</b>' + place.AddressDetails.Accuracy + '<br>' +
        '<b>Country code:</b> ' + place.AddressDetails.Country.CountryNameCode);
            }
        });
    });


    $('#btnSetAddress').click(function() {
        var address = $('#address').val();
        map.clearOverlays();

        geocoder.getLatLng(address, function(point) {
            if (!point) {
                alert("无法解析:" + address);
            } else {
                map.setCenter(point, 13);
                var marker = new GMarker(point);
                map.addOverlay(marker);
            }
        });
    });

    $('#btnInfoWindow').click(function() {
        var info = $('#info').val();
        if (info == null || info == "") {
            info = "hello world";
        }
        var center = map.getCenter();
        map.clearOverlays();
        var marker = new GMarker(center);
        map.addOverlay(marker);
        marker.openInfoWindowHtml(info);
    });

    // ContextMenu事件处理 ==========================================================

    $('#mGetLngLat').click(function() {
        if (clickedPoint != null) {
            $('#contextMenu').hide();
            var point = map.fromContainerPixelToLatLng(clickedPoint)
            $('#lng').val(point.lng());
            $('#lat').val(point.lat());
        }
    });

    $('#mGetAddress').click(function() {
        if (clickedPoint != null) {
            $('#contextMenu').hide();
            var point = map.fromContainerPixelToLatLng(clickedPoint)
            geocoder.getLocations(point, function(response) {
                if (!response || response.Status.code != 200) {
                    alert("Status Code:" + response.Status.code);
                } else {
                    place = response.Placemark[0];
                    $('#address').val(place.address);
                }
            });

        }
    });

    $('#mSetCenter').click(function() {
        if (clickedPoint != null) {
            $('#contextMenu').hide();
            var point = map.fromContainerPixelToLatLng(clickedPoint)
            map.setCenter(point);
        }
    });

    $('#mAddMarker').click(function() {
        if (clickedPoint != null) {
            $('#contextMenu').hide();
            var point = map.fromContainerPixelToLatLng(clickedPoint)
            var marker = new GMarker(point);
            map.addOverlay(marker);
        }
    });

    $('#mRemoveMarker').click(function() {
        if (clickedMarker != null) {
            $('#contextMenu').hide();
            map.removeOverlay(clickedMarker);
        }
    });

    // 地图事件处理 =================================================================

    GEvent.addListener(map, "click", function(overlay, latlng, overlaylatlng) {
        var $contextMenu = $('#contextMenu');
        if ($contextMenu.css('display') != 'none') {
            $('#contextMenu').hide();
            return;
        }
        if (overlay == null) {
            var marker = new GMarker(latlng);
            map.addOverlay(marker);
            $('#lat').val(latlng.lat());
            $('#lng').val(latlng.lng());
            geocoder.getLocations(latlng, function(response) {
                if (!response || response.Status.code != 200) {
                    alert("Status Code:" + response.Status.code);
                } else {
                    place = response.Placemark[0];
                    $('#address').val(place.address);
                }
            });
        }
        else if (overlay.openInfoWindowHtml) {
            geocoder.getLocations(overlaylatlng, function(response) {
                if (!response || response.Status.code != 200) {
                } else {
                    place = response.Placemark[0];

                    overlay.openInfoWindowHtml(
        '<b>orig latlng:</b>' + response.name + '<br/>' +
        '<b>latlng:</b>' + place.Point.coordinates[0] + "," + place.Point.coordinates[1] + '<br>' +
        '<b>Status Code:</b>' + response.Status.code + '<br>' +
        '<b>Status Request:</b>' + response.Status.request + '<br>' +
        '<b>Address:</b>' + place.address + '<br>' +
        '<b>Accuracy:</b>' + place.AddressDetails.Accuracy + '<br>' +
        '<b>Country code:</b> ' + place.AddressDetails.Country.CountryNameCode);
                }
            });
        }
    });

    GEvent.addListener(map, "singlerightclick", function(point, src, overlay) {
        clickedPoint = point;
        clickedMarker = overlay;
        var x = point.x;
        var y = point.y;
        if (x > map.getSize().width - 120) { x = map.getSize().width - 120 }
        if (y > map.getSize().height - 100) { y = map.getSize().height - 100 }
        var pos = new GControlPosition(G_ANCHOR_TOP_LEFT, new GSize(x, y));
        pos.apply($('#contextMenu')[0]);
        if (overlay == null) {
            $('#mAddMarker').show();
            $('#mRemoveMarker').hide();
        }
        else {
            $('#mAddMarker').hide();
            $('#mRemoveMarker').show();
        }
        $('#contextMenu').show();
    });
});
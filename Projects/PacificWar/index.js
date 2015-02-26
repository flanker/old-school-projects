/// <reference path="google-maps-3-vs-1-0.js" />

var tl;
var tlEventSource;
var jsonData;
var map;
var markers = [];
var infoWindow;
var currIndex = -1;
var eventCount = 0;

var image = new google.maps.MarkerImage('yellow_marker_sprite.png',
      new google.maps.Size(20, 32),
      new google.maps.Point(0, 0),
      new google.maps.Point(10, 32));
var shadow = new google.maps.MarkerImage('yellow_marker_sprite.png',
      new google.maps.Size(37, 32),
      new google.maps.Point(20, 0),
      new google.maps.Point(10, 32));
var shape = {
    coord: [1, 1, 1, 20, 18, 20, 18, 1],
    type: 'poly'
};

var createTimeline = function() {

    tlEventSource = new Timeline.DefaultEventSource();

    var theme1 = Timeline.ClassicTheme.create();
    theme1.timeline_start = new Date(Date.UTC(1930, 0, 1));
    theme1.timeline_stop = new Date(Date.UTC(1950, 0, 1));

    var d = Timeline.DateTime.parseGregorianDateTime('1942');

    var zones = [{ start: '1941-12-07', end: '1941-12-10', unit: Timeline.DateTime.DAY, magnify: 20}];

    var bandInfos = [
                Timeline.createHotZoneBandInfo({
                    width: '80%',
                    intervalUnit: Timeline.DateTime.MONTH,
                    intervalPixels: 100,
                    zones: zones,
                    eventSource: tlEventSource,
                    date: d,
                    theme: theme1,
                    layout: 'original'  // original, overview, detailed
                }),
                Timeline.createBandInfo({
                    width: '20%',
                    intervalUnit: Timeline.DateTime.YEAR,
                    intervalPixels: 120,
                    eventSource: tlEventSource,
                    date: d,
                    theme: theme1,
                    layout: 'overview'  // original, overview, detailed
                })];

    bandInfos[1].syncWith = 0;
    bandInfos[1].highlight = true;
    bandInfos[1].decorators = [
            new Timeline.SpanHighlightDecorator({
                startDate: '1941-12-07',
                endDate: '1945-09-02',
                startLabel: "Start",
                endLabel: "End",
                color: "#FFC080",
                opacity: 50,
                theme: theme1
            })
        ];

    tl = Timeline.create(document.getElementById('tl'), bandInfos);

    tl.layout();
}

var createMap = function() {
    var myLatlng = new google.maps.LatLng(13.444304, 144.793731);
    var myOptions = {
        zoom: 3,
        center: myLatlng,
        mapTypeControl: true,
        mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
        streetViewControl: false,
        navigationControl: true,
        navigationControlOptions: { style: google.maps.NavigationControlStyle.DEFAULT },
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    map = new google.maps.Map(document.getElementById('map'), myOptions);

    infoWindow = new google.maps.InfoWindow({
        content: ''
    });

    createTimeController();
}

var loadJson = function(jsonFile) {
    tl.loadJSON(jsonFile + '?' + (new Date().getTime()), function(json, url) {
        jsonData = json;
        tlEventSource.loadJSON(json, url);
        createMapMarkers();
        eventCount = jsonData.events.length;
        tl.layout();
    });
}

var createMapMarkers = function() {
    for (var i = 0; i < jsonData.events.length; i++) {
        var d = jsonData.events[i];
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(d.lat, d.lng),
            map: map,
            title: d.title,
            ZIndex: 0
        });
        markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function(i) {
            return function(event) {
                goEvent(i);
            }
        })(i)); // use closure
    }
}

var getContent = function(evt) {
    var content = '<div class="infoContent">';
    content += '<div class="infoContent-title">' + evt.title + '</div>';
    content += '<div class="infoContent-start"><span class="infoContent-label">Start: </span>' + evt.start + '</div>';
    content += '<div class="infoContent-end"><span class="infoContent-label">End: </span>' + evt.end + '</div>';
    content += '<div class="infoContent-location"><span class="infoContent-label">Location: </span>' + evt.location + '</div>';
    content += '<div class="infoContent-description"><span class="infoContent-label">Description: </span>' + evt.description + '</div>';
    content += '<div class="infoContent-wiki"><a href="' + evt.wiki + '" target="_blank">See on Wiki</div>';
    content += '</div>';
    return content;
}

Timeline.OriginalEventPainter.prototype._showBubble = function(x, y, evt) {
    goEvent(evt.getID());
}

var createTimeControllerDiv = function(title, display, goFunction) {
    var contDiv = document.createElement('div');
    contDiv.style.backgroundColor = 'white';
    contDiv.style.borderStyle = 'solid';
    contDiv.style.borderWidth = '1px';
    contDiv.style.width = '20px';
    contDiv.style.height = '15px';
    contDiv.style.cursor = 'pointer';
    contDiv.style.textAlign = 'center';
    contDiv.style.cssFloat = 'left';
    contDiv.style.fontSize = '9px';
    //contDiv.style.fontWeight = 'bold';
    contDiv.style.paddingTop = '4px';
    contDiv.title = title;
    contDiv.innerHTML = display;

    google.maps.event.addDomListener(contDiv, 'click', goFunction);

    return contDiv;
}

var createTimeController = function() {
    var timeControlDiv = document.createElement('div');
    timeControlDiv.style.borderStyle = 'solid';
    timeControlDiv.style.borderWidth = '1px';
    timeControlDiv.style.marginTop = '5px';

    timeControlDiv.appendChild(createTimeControllerDiv('first', '<<', goFirst));
    timeControlDiv.appendChild(createTimeControllerDiv('previous', '<', goPrevious));
    timeControlDiv.appendChild(createTimeControllerDiv('next', '>', goNext));
    timeControlDiv.appendChild(createTimeControllerDiv('last', '>>', goLast));

    timeControlDiv.index = 1;
    map.controls[google.maps.ControlPosition.TOP].push(timeControlDiv);
}

var goFirst = function() {
    goEvent(0);
}

var goPrevious = function() {
    if (currIndex != 0)
        goEvent(currIndex - 1);
}

var goNext = function() {
    if (currIndex != eventCount - 1)
        goEvent(currIndex + 1);
}

var goLast = function() {
    goEvent(eventCount - 1);
}

var goEvent = function(i) {
    if (currIndex >= 0) {
        markers[currIndex].setIcon(undefined);
        markers[currIndex].setShadow(undefined);
        markers[currIndex].setZIndex(0);
        tlEventSource.getEvent(currIndex)._icon = null;
    }
    markers[i].setIcon(image);
    markers[i].setShadow(shadow);
    markers[i].setZIndex(10);
    map.setCenter(markers[i].position);
    infoWindow.setContent(getContent(jsonData.events[i]));
    infoWindow.open(map, markers[i]);
    tlEventSource.getEvent(i)._icon = 'green-circle.png';
    tl.getBand(0).scrollToCenter(Timeline.DateTime.parseGregorianDateTime(jsonData.events[i].start));
    currIndex = i;
    tl.layout(); // display the Timeline
}

var onLoad = function() {

    createTimeline();
    createMap();

    loadJson('data_pacific_war.js');
}
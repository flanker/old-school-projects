/********************************
/* timeline map javascript lib
/* flanker (flankerfc <at> gmail.com)
/* 2010-10-30
/* SIMILE Timeline: http://www.simile-widgets.org/timeline/
/* Google Map: http://code.google.com/apis/maps/documentation/javascript/
/********************************/

function Timemap(timemapConfig) {

    this._timeline = undefined;
    this._tlEventSource = undefined;
    this._jsonData = undefined;
    this._map = undefined;
    this._infoWindow = undefined;
    this._markers = [];
    this._currIndex = -1;
    this._eventCount = 0;

    // create timeline

    this._tlEventSource = new Timeline.DefaultEventSource();

    var theme = Timeline.ClassicTheme.create();
    theme.timeline_start = new Date(Date.UTC(1930, 0, 1));
    theme.timeline_stop = new Date(Date.UTC(1950, 0, 1));

    var initDate = Timeline.DateTime.parseGregorianDateTime('1942');

    var zones = [{ start: '1941-12-07', end: '1941-12-10', unit: Timeline.DateTime.DAY, magnify: 20}];

    var bandInfos = [
                Timeline.createHotZoneBandInfo({
                    width: '80%',
                    intervalUnit: Timeline.DateTime.MONTH,
                    intervalPixels: 100,
                    zones: zones,
                    eventSource: this._tlEventSource,
                    date: initDate,
                    theme: theme,
                    layout: 'original'  // original, overview, detailed
                }),
                Timeline.createBandInfo({
                    width: '20%',
                    intervalUnit: Timeline.DateTime.YEAR,
                    intervalPixels: 120,
                    eventSource: this._tlEventSource,
                    date: initDate,
                    theme: theme,
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
                theme: theme
            })
        ];

    this._timeline = Timeline.create(document.getElementById(timemapConfig.timeId), bandInfos);

    this._timeline._bandInfos[0].eventPainter._showBubble = function(tm) {
        return function(x, y, evt) {
            tm.goEvent(evt.getID());
        };
    } (this);

    this._timeline.layout();

    // create map

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

    this._map = new google.maps.Map(document.getElementById(timemapConfig.mapId), myOptions);

    this._infoWindow = new google.maps.InfoWindow({ content: '' });

    // create map time controller

    var timeControlDiv = document.createElement('div');
    timeControlDiv.style.borderStyle = 'solid';
    timeControlDiv.style.borderWidth = '1px';
    timeControlDiv.style.marginTop = '5px';

    timeControlDiv.appendChild(this.createTimeControllerDiv('first', '<<', this.goFirst));
    timeControlDiv.appendChild(this.createTimeControllerDiv('previous', '<', this.goPrevious));
    timeControlDiv.appendChild(this.createTimeControllerDiv('next', '>', this.goNext));
    timeControlDiv.appendChild(this.createTimeControllerDiv('last', '>>', this.goLast));

    timeControlDiv.index = 1;
    this._map.controls[google.maps.ControlPosition.TOP].push(timeControlDiv);
}

Timemap.prototype.createTimeControllerDiv = function(title, display, goFunction) {
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

    google.maps.event.addDomListener(contDiv, 'click', function(tm) {
        return function() {
            goFunction.apply(tm);
        };
    } (this));

    return contDiv;
};

Timemap.prototype.loadJson = function(file) {
    this._timeline.loadJSON(file + '?' + (new Date().getTime()), function(tm) {
        return function(json, url) {
            tm._jsonData = json;
            tm._tlEventSource.loadJSON(json, url);
            tm.createMapMarkers();
            tm._eventCount = tm._jsonData.events.length;
            tm._timeline.layout();
        };
    } (this));
};

Timemap.prototype.createMapMarkers = function() {
    for (var i = 0; i < this._jsonData.events.length; i++) {
        var d = this._jsonData.events[i];
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(d.lat, d.lng),
            map: this._map,
            title: d.title,
            ZIndex: 0
        });
        this._markers.push(marker);
        google.maps.event.addListener(marker, 'click', (function(i, tm) {
            return function(event) {
                tm.goEvent(i);
            }
        })(i, this)); // use closure
    }
};

Timemap.prototype.goEvent = function(i) {
    if (this._currIndex >= 0) {
        this._markers[this._currIndex].setIcon(undefined);
        this._markers[this._currIndex].setShadow(undefined);
        this._markers[this._currIndex].setZIndex(0);
        this._tlEventSource.getEvent(this._currIndex)._icon = null;
    }
    this._markers[i].setIcon(Timemap.YellowMarkerImage);
    this._markers[i].setShadow(Timemap.YellowMarkerShadow);
    this._markers[i].setZIndex(10);
    this._map.setCenter(this._markers[i].position);
    this._infoWindow.setContent(this.getContent(this._jsonData.events[i]));
    this._infoWindow.open(this._map, this._markers[i]);
    this._tlEventSource.getEvent(i)._icon = '/content/demo/pacific-war-timeline-map/green-circle.png';
    this._timeline.getBand(0).scrollToCenter(Timeline.DateTime.parseGregorianDateTime(this._jsonData.events[i].start));
    this._currIndex = i;
    this._timeline.layout(); // display the Timeline
};

Timemap.prototype.goFirst = function() {
    this.goEvent(0);
}

Timemap.prototype.goPrevious = function() {
    if (this._currIndex != 0)
        this.goEvent(this._currIndex - 1);
}

Timemap.prototype.goNext = function() {
    if (this._currIndex != this._eventCount - 1)
        this.goEvent(this._currIndex + 1);
}

Timemap.prototype.goLast = function() {
    this.goEvent(this._eventCount - 1);
}

Timemap.prototype.getContent = function(evt) {
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


Timemap.YellowMarkerImage = new google.maps.MarkerImage('/content/demo/pacific-war-timeline-map/yellow_marker_sprite.png',
      new google.maps.Size(20, 32),
      new google.maps.Point(0, 0),
      new google.maps.Point(10, 32));
Timemap.YellowMarkerShadow = new google.maps.MarkerImage('/content/demo/pacific-war-timeline-map/yellow_marker_sprite.png',
      new google.maps.Size(37, 32),
      new google.maps.Point(20, 0),
      new google.maps.Point(10, 32));
Timemap.YellowMarkerShape = {
    coord: [1, 1, 1, 20, 18, 20, 18, 1],
    type: 'poly'
};
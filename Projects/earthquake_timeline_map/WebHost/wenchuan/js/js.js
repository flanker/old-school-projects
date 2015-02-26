// JavaScript Document

	var map;
	var tl;
	var baseIcon;
	
	var mapLevel = 3;
	
	var eventNumber;
	
	var latlngs = new Array();
	var infos = new Array();
	var dates = new Array();
	var titles = new Array();
	
//--------------------------------------------------------------��ʼ��
	
function initialize() {
	if (GBrowserIsCompatible()) {
		
        map = new GMap2(document.getElementById("map_canvas"));//���ĵ�idΪmap_canvas�У�index.html�У�����Google Map���� GMap2
        map.setCenter(new GLatLng(32, 104), mapLevel);//��ʼ�����ĵ�
		map.setMapType(G_SATELLITE_MAP);//��ʼ����ʾ��������ģʽͼ��֧�����ǡ���ͨ�ֵ����������ͼ��
		map.enableScrollWheelZoom();   //��ʼ��֧�ֹ��ַŴ���С 	
		map.addControl(new GLargeMapControl());	//��ʼ����ͼ����̨	
		map.addControl(new GMapTypeControl());		//��ʼ����ͼ�����л�̨
		map.addControl(new GOverviewMapControl());  //��ʼ�����½�������ͼ		
		
		baseIcon = new GIcon();  //����ͼ��
		baseIcon.shadow = "images/mapfiles/shadow50.png"; //ͼ����Ӱ
		baseIcon.iconSize = new GSize(20, 34); 
		baseIcon.shadowSize = new GSize(37, 34);
		baseIcon.iconAnchor = new GPoint(9, 34);
		baseIcon.infoWindowAnchor = new GPoint(9, 2);
		baseIcon.infoShadowAnchor = new GPoint(18, 25);


		GDownloadUrl("../Earthquake.svc/GetEvents/week", function(data, responseCode) {
//��http://flankerfc.cn/Earthquake.svc/GetEvents/week�л�ȡxml�����ĵ�
			var xml = GXml.parse(data); //����xml������
			//var xml = xmlhttp.responseXML; 

			var markers = xml.documentElement.getElementsByTagName("Event"); //�������
			
			var menu = document.getElementById("menu");			
			
			eventNumber = markers.length;
			
			document.getElementById("eventNumber").innerHTML = eventNumber;
			
			for (var i = 0; i < eventNumber; i++) {

				
                latlngs[i] = new GLatLng(GXml.value(markers[i].getElementsByTagName("Lat")[0]),
                                         GXml.value(markers[i].getElementsByTagName("Lng")[0]));
                infos[i] = GXml.value(markers[i].getElementsByTagName("Info")[0]);
                dates[i] = GXml.value(markers[i].getElementsByTagName("Start")[0]);
                titles[i] = GXml.value(markers[i].getElementsByTagName("Title")[0]);
			}
			 //�����ݷֱ��������
			aferGDownload();			
		});
	}
	
	function aferGDownload() {
	//����Timeline
	var eventSource = new Timeline.DefaultEventSource();
  
	var bandInfos = [//��������band
		Timeline.createBandInfo({//��Timeline��band�ĸ�ʽ����
        	eventSource:    eventSource,
        	date:           "May 17 2008 17:00:00 GMT+0000",//��ʼ����
			minDate:		"Jan 01 2008 00:00:00 GMT+0000",
			maxDate:		"Jan 01 2050 00:00:00 GMT+0000",
        	width:          "80%", 
        	intervalUnit:   Timeline.DateTime.HOUR, //ʱ�䵥λ
        	intervalPixels: 90//ÿһʱ�䵥λ�Ŀ�ȣ�����ֵ��
    	}),
    	Timeline.createBandInfo({
			showEventText:  false,
        	trackHeight:    1,
        	trackGap:       1,
        	eventSource:    eventSource,
        	date:           "May 17 2008 17:00:00 GMT+0000",
			minDate:		"Jan 01 2008 00:00:00 GMT+0000",
			maxDate:		"Jan 01 2050 00:00:00 GMT+0000",
        	width:          "20%", 
        	intervalUnit:   Timeline.DateTime.DAY, 
        	intervalPixels: 300
    	})
	];
  
	bandInfos[1].syncWith = 0; //band1��band0ͬ��
	bandInfos[1].highlight = true;
  
	tl = Timeline.create(document.getElementById("timeline_canvas"), bandInfos);
	Timeline.loadXML("../Earthquake.svc/GetEvents/week", function(xml, url) { eventSource.loadXML(xml, url); });
	
	//updateMenu();
	
	for (var i = 0; i < eventNumber; i++) {
						
		map.addOverlay(createMarker(i));
	}
	
	document.getElementById("loading").innerHTML = "";
	
	}
}

function createMarker(number, markerNumber) {	//�����𼶴���googleͼ��
			
	var level;  
	

	
	level = Math.floor(titles[number].substring(2,4));	//��ȡ��
	var letteredIcon = new GIcon(baseIcon);  
	letteredIcon.image = "images/mapfiles/marker" + level + "+.png";  
	markerOptions = { icon:letteredIcon };  
			
	var marker = new GMarker(latlngs[number], markerOptions);
	marker.value = number+1;
	GEvent.addListener(marker, "click", function() {
		showMarker(number, map.getZoom());
	});
	return marker;
}

function updateMenu() {//���Menu��δʹ�ã�
	
	document.getElementById("menu").innerHTML = "";
	
	//map.clearOverlays();
	
	//var leftDate = new Date(tl.getBand(0).getEther().pixelOffsetToDate(dstOffset));
	
	var menuNumber = 0;
	
	for (var i = 0; i < eventNumber; i++) {
						
		map.addOverlay(createMarker(i, menuNumber));
				
		//var letter = String.fromCharCode("A".charCodeAt(0) + menuNumber); 	
		
		document.getElementById("menu").innerHTML +="<li><a href='javascript:showMarker(" + i.toString() + ",13);'>" + ". " + titles[i] + "</a></li>";

		menuNumber++;

	}
}


//-------------------------------------------------------------- Google Maps

function mapZoomIn() {
	map.zoomIn();
}

function showMarker(number, level) {//Timeline��Google Mapͬ��
	map.setCenter(latlngs[number], level);//���õ�ͼ�е�
	centerTimeline(number);//Timeline�е�
	map.openInfoWindowHtml(latlngs[number], infos[number]);//�򿪸�Event����ʾ����
}

var lines;

function showLines() {
	lines = new GPolyline(latlngs, "#ff0000", 2);
	map.addOverlay(lines);
	document.getElementById("showLines").className='hide';
	document.getElementById("hideLines").className='';
}

function hideLines() {
	map.removeOverlay(lines);
	document.getElementById("showLines").className='';
	document.getElementById("hideLines").className='hide';
}

//-------------------------------------------------------------- Timeline

function centerTimeline(i) {//
	//tl.getBand(0).setCenterVisibleDate(Timeline.DateTime.parseGregorianDateTime(dates[i]));
	tl.getBand(0).scrollToCenter(Timeline.DateTime.parseGregorianDateTime(dates[i]));
	
	//var dstOffset = (tl.getBand(0).getEther().dateToPixelOffset(new Date(dates[i])) - document.getElementById("timeline_canvas").offsetWidth / 2)
	
	//updateMenu(i);
}

Timeline.DurationEventPainter.prototype._showBubble = function(x, y, evt) {

	showMarker(evt.getDescription()-0, mapLevel);
}

//-------------------------------------------------------------- Test

function test() {
	alert(tl.getBand(0).getEther().pixelOffsetToDate(0));
}




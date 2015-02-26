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
	
//--------------------------------------------------------------初始化
	
function initialize() {
	if (GBrowserIsCompatible()) {
		
        map = new GMap2(document.getElementById("map_canvas"));//在文档id为map_canvas中（index.html中）创建Google Map对象 GMap2
        map.setCenter(new GLatLng(32, 104), mapLevel);//初始化中心点
		map.setMapType(G_SATELLITE_MAP);//初始化显示的是卫星模式图（支持卫星、普通街道、混合三种图）
		map.enableScrollWheelZoom();   //初始化支持滚轮放大缩小 	
		map.addControl(new GLargeMapControl());	//初始化地图控制台	
		map.addControl(new GMapTypeControl());		//初始化地图种类切换台
		map.addControl(new GOverviewMapControl());  //初始化右下角略缩地图		
		
		baseIcon = new GIcon();  //创建图标
		baseIcon.shadow = "images/mapfiles/shadow50.png"; //图标阴影
		baseIcon.iconSize = new GSize(20, 34); 
		baseIcon.shadowSize = new GSize(37, 34);
		baseIcon.iconAnchor = new GPoint(9, 34);
		baseIcon.infoWindowAnchor = new GPoint(9, 2);
		baseIcon.infoShadowAnchor = new GPoint(18, 25);


		GDownloadUrl("../Earthquake.svc/GetEvents/week", function(data, responseCode) {
//从http://flankerfc.cn/Earthquake.svc/GetEvents/week中获取xml数据文档
			var xml = GXml.parse(data); //创建xml解析器
			//var xml = xmlhttp.responseXML; 

			var markers = xml.documentElement.getElementsByTagName("Event"); //建立标记
			
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
			 //将数据分别读入数组
			aferGDownload();			
		});
	}
	
	function aferGDownload() {
	//生成Timeline
	var eventSource = new Timeline.DefaultEventSource();
  
	var bandInfos = [//创建两个band
		Timeline.createBandInfo({//按Timeline中band的格式创建
        	eventSource:    eventSource,
        	date:           "May 17 2008 17:00:00 GMT+0000",//开始日期
			minDate:		"Jan 01 2008 00:00:00 GMT+0000",
			maxDate:		"Jan 01 2050 00:00:00 GMT+0000",
        	width:          "80%", 
        	intervalUnit:   Timeline.DateTime.HOUR, //时间单位
        	intervalPixels: 90//每一时间单位的宽度（像素值）
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
  
	bandInfos[1].syncWith = 0; //band1与band0同步
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

function createMarker(number, markerNumber) {	//根据震级创建google图标
			
	var level;  
	

	
	level = Math.floor(titles[number].substring(2,4));	//获取震级
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

function updateMenu() {//左侧Menu（未使用）
	
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

function showMarker(number, level) {//Timeline与Google Map同步
	map.setCenter(latlngs[number], level);//设置地图中点
	centerTimeline(number);//Timeline中点
	map.openInfoWindowHtml(latlngs[number], infos[number]);//打开该Event的提示窗口
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




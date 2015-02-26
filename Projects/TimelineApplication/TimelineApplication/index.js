var tl;
function onLoad() {

    var eventSource1 = new Timeline.DefaultEventSource();

    var theme1 = Timeline.ClassicTheme.create();
    theme1.timeline_start = new Date(Date.UTC(1890, 0, 1));
    theme1.timeline_stop = new Date(Date.UTC(2160, 0, 1));

    var d = Timeline.DateTime.parseGregorianDateTime("1900")

    var bandInfos = [
                    Timeline.createBandInfo({
                        width: "70%",
                        intervalUnit: Timeline.DateTime.MONTH,
                        intervalPixels: 100,
                        eventSource: eventSource1,
                        date: d,
                        theme: theme1,
                        layout: 'original'  // original, overview, detailed
                    }),
                    Timeline.createBandInfo({
                        width: "30%",
                        intervalUnit: Timeline.DateTime.YEAR,
                        intervalPixels: 200,
                        eventSource: eventSource1,
                        date: d,
                        theme: theme1,
                        layout: 'original'  // original, overview, detailed
                    })
            ];

    bandInfos[1].syncWith = 0;
    bandInfos[1].highlight = true;

    tl = Timeline.create(document.getElementById("timelineDiv"), bandInfos);

    eventSource1.loadJSON(timeline_data, '.');

    tl.layout(); // display the Timeline
}
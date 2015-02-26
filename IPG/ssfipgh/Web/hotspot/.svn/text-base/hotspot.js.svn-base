///<reference path="../js/jquery-1.3.2-vsdoc2.js" />

$(document).ready(function() {
    // set opacity
    $(".hotSpotTitle > div").css("opacity", "0.4");
    $(".hotSpotContent > div").css("opacity", "0.6");

    // hide hot spot
    $(".hotSpotTitle > div").hide();
    $(".hotSpotContent").hide();

    // show title
    $(".hotSpotTitle").mouseenter(function() {
        $("div", this).show();
    });

    // show content
    $(".hotSpotTitle > div").mouseenter(function() {
        $(this).parent().next().fadeIn(1000);
    });

    // hide hot spot
    $(".hotSpot").mouseleave(function() {
        $(".hotSpotTitle div", this).hide();
        $(".hotSpotContent", this).hide();
    });
});
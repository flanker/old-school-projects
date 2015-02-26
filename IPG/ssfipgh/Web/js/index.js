///<reference path="jquery-1.3.2-vsdoc2.js" />

// 登录效果
$(document).ready(function() {
    $("div#header").hide();

    // toggle Panel
    $("#loginToggler").click(function() {
        $("div#header").slideToggle("slow");
        return false;
    });
    // close Panel
    $("#loginClose").click(function() {
        $("div#header").slideUp("slow");
        return false;
    });
});

// navigation facebox modal form
$(document).ready(function() {
    $('a[rel*=facebox]').facebox();

    // show facebox content if page are redirected from other pages
    if (document.referrer) {
        $('a[rel*=facebox]').each(function() {
            if (this.href == document.referrer) {
                $(this).click();
            }
        });
    }
})

// tab效果, 阴影效果
$(document).ready(function() {
    $("#tabMenu ul").hide();

    $("#tabMenu > a").mouseenter(function() {
        $("#tabMenu ul").hide();
        $("#tabMenu > a").removeClass("tabMenuAHover");
        $(this).addClass("tabMenuAHover").next().show();

        $("#overlayer").css({ "visibility": "visible", "opacity": 0.5 })
            .width($("body").width())
            .height($("body").height() + 200);
    });

    $("#tabMenu").hover(function() {
    }, function() {
        $("#tabMenu ul").hide();
        $("#tabMenu > a").removeClass("tabMenuAHover");

        $("#overlayer").css({ "visibility": "hidden", "opacity": 0 })
            .width(0).height(0);
    });
});
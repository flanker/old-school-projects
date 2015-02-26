/// <reference path="jquery-1.3.2-vsdoc.js" />

var postBegin = function() {
    if ($('#Description').val() == '') {
        alert('内容不能为空');
        return false;
    }
    $("#overlayer").css({ "visibility": "visible", "opacity": 0.5 });
};

var postComplete = function() {
    $("#overlayer").css({ "visibility": "hidden", "opacity": 0 });
};

var ajaxFailure = function(ajaxContext) {
    alert(ajaxContext.get_data());
};

var afterPostSuccess = function() {
    $('#Description').val('');
    $('#todos li:eq(0)').effect('highlight', null, 2000);

//    var test = $('#process-total').text();
//    $('#process-total').html('1');
};

var deleteSuccess = function(ajaxContext) {
//    var id = '#item-' + ajaxContext.get_data();
//    $(id).remove();

//    var test = $('#process-total').text();
//    $('#process-total').text(test - 1);
};

var finishSuccess = function(ajaxContext) {
//    var id = '#item-' + ajaxContext.get_data();
//    var html = $('.item-desc', id).html();
//    $('.item-desc', id).html('<img src="/Content/Images/heart.png" alt="已完成" /> ' + html);

//    var test = $('#process-finished').text();
//    $('#process-finished').text(test + 1);
};
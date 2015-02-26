/// <reference path="jquery-1.3.2-vsdoc.js" />

var afterPostSuccess = function() {
    $("#Description").val('');
    $("#todos li:eq(0)").effect('highlight', null, 2000);
};

var postBegin = function() {
    if ($("#Description").val() == '') {
        alert("内容不能为空");
        return false;
    }
};

var afterPostFailure = function() {
    alert("添加失败");
};

$(document).ready(function() {
    $('.rounded').corner();
});

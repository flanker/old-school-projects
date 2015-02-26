/// <reference path="../jquery.min-vsdoc.js" />

/*
function uploadFile() {
document.getElementById("uploadMessage").style.display = "none";
var file = document.getElementById("fileToUpload");
var uploadFormElement = document.getElementById("uploadForm");

// display progress bar
document.getElementById("progressBar").style.display = "block";

// copy elements
uploadFormElement.removeChild(uploadFormElement.fileToUpload);
uploadFormElement.appendChild(file);
document.getElementById("fileUploadDiv").innerHTML = '<input type="file" id="fileToUpload" name="fileToUpload" size="50" />';

// submit
uploadFormElement.submit();
}

function uploadFileResponse(response) {
document.getElementById("progressBar").style.display = "none";
var errLabel = document.getElementById("uploadMessage");
errLabel.innerHTML = "";
eval("var k=" + response);
if (k.status > 0) {
errLabel.style.display = "block";
errLabel.innerHTML = k.message;
} else
alert(k.message);
}
*/

function uploadFile() {

    $('#uploadMessage').hide();
    var file = document.getElementById("fileToUpload");
    var uploadFormElement = document.getElementById("uploadForm");

    $('#progressBar').show();

    uploadFormElement.removeChild(uploadFormElement.fileToUpload);
    uploadFormElement.appendChild(file);
    $('#fileUploadDiv').html('<input type="file" id="fileToUpload" name="fileToUpload" size="50" />');

    uploadFormElement.submit();
}

function uploadFileResponse(response) {
    $('#progressBar').hide();

    var errLabel = $('#uploadMessage');
    errLabel.html('');
    eval("var k=" + response);
    if (k.status > 0) {
        errLabel.show();
        errLabel.html(k.message);
    } else
        $('#Content').html(k.message);
}
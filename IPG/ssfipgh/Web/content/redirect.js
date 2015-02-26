// use this javascript file to redirect to index.html
// the index.html page will show content in facebox

if (window.ActiveXObject) {
    window.onload = function() {
        var f = document.createElement('form');
        f.action = "../index.html";
        document.body.appendChild(f);
        f.submit();
    }
}
else {
    location = "../index.html";
}

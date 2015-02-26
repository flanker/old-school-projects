<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head>
    <title>LocalStorage</title>
    <script src="/Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            if (window.localStorage) {
                var result = localStorage.getItem('result');
                if (result) {
                    $('#result').text(result);
                }
            }


            $.get('getajaxresultwithhttpcache', function(data) {
                $('#result').text(data);
                localStorage.setItem('result', data)
            });
        });
    </script>
</head>
<body>
    <div>
        <h1 id="result">loading...</h1>
    </div>
</body>
</html>

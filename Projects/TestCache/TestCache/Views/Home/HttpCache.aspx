<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head>
    <title>HttpRequest</title>
    <script src="/Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('#result').load('getajaxresultwithhttpcache');
        });
    </script>
</head>
<body>
    <div>
        <h1 id="result">loading...</h1>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DakkaWeb.Views.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Login</title>
    <link href="../../Extjs/resources/css/ext-all.css" rel="stylesheet" type="text/css" />

    <script src="../../Extjs/adapter/ext/ext-base.js" type="text/javascript"></script>

    <script src="../../Extjs/ext-all-debug.js" type="text/javascript"></script>

    <script src="../../Scripts/Account/Login.js" type="text/javascript"></script>

    <style type="text/css">
        #main
        {
            margin: 100px auto;
            width : 350px;
        }
        #loginDiv
        {
            margin: auto;
        }
    </style>
</head>
<body>
    <div id="main">
        <p>welcome to Dakka</p>
        <div id="loginDiv">
        </div>
        <%= Html.ValidationSummary() %>
    </div>
</body>
</html>

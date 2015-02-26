<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <script src="/Content/jquery.min.js" type="text/javascript"></script>
    <script src="/Content/Upload/upload.js" type="text/javascript"></script>
</head>
<body>
    <div>
        <div id="Content">
        </div>
        <div>
            Upload file:
            <span id="fileUploadDiv">
                <input type="file" id="fileToUpload" name="fileToUpload" size="50" />
            </span>
            <input type="button" id="uploadButton" onclick="uploadFile();" value="Upload" />
            <span id="uploadMessage" style="border: 1px solid #cccccc; color: Red; display: none">
            </span>
        </div>
        <div id="progressBar" style="display: none; position: absolute; color: #660066; font-family: Arial;">
            <img src="/Content/Upload/loading.gif" alt="uploading..." />
            File is uploading...
        </div>
    </div>
    <div style="display: none;">
        <iframe name="uploadResponse"></iframe>
        <% using (Html.BeginForm("Upload", "Upload", FormMethod.Post, new { id = "uploadForm", target = "uploadResponse", enctype = "multipart/form-data" }))
           {
        %>
        <input type="file" name="fileToUpload" size="50" value="" />
        <%
            }
        %>
    </div>
</body>
</html>

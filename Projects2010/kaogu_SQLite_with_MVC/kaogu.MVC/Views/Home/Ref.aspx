<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<kaogu.MVC.Controllers.RefModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%= Model.Name %></title>
</head>
<body>
    <div>
        <h1><%= Model.Name %></h1>
    </div>
    <table>
        <thead>
            <tr>
                <% foreach (var field in Model.Fields)
                   {
                %>
                <td><%= field %></td>
                <%
                   } 
                %>
            </tr>
        </thead>
        <tbody>
            <% foreach (var record in Model.Records)
                {
            %>
            <tr>
                <% foreach (var field in Model.Fields)
                {
                %>
                    <td><% %></td>
                <%
                } 
                %>
            </tr>
            <%
                } 
            %>
        </tbody>
    </table>
</body>
</html>

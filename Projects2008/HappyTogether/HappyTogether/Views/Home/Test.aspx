<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Test
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Test</h2>
    <p>
        <%= Html.ViewData["ReferenceEquals"].ToString() %></p>
    <p>
        <%= Html.ViewData["RawUrl"].ToString()%></p>
    <p>
        <%= Html.ViewData["HttpMethod"].ToString()%></p>
    <p>
        <%= Html.ViewData["QueryString"].ToString()%></p>
    <p>QueryString</p>
    <p>
        <% NameValueCollection qs = ViewData["QueryString"] as NameValueCollection;
           foreach (var key in qs)
           {%>
        <%= key.ToString() %>£º<%= qs[key.ToString()].ToString() %>
        <%
            }
        %></p>
    <p>Form</p>
    <p>
        <% NameValueCollection f = ViewData["Form"] as NameValueCollection;
           foreach (var key in f)
           {%>
        <%= key.ToString() %>£º<%= f[key.ToString()].ToString()%>
        <%
            }
        %></p>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Life/life.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="main">
        <img id="twitter-logo" src="/Content/Life/twitter_logo.png" alt="twitter" />
        <a href="http://twitter.com/flankerfc" id="twitter-link">follow me on Twitter</a>
        <div id="twitter_div">
            <% if (User.Identity.IsAuthenticated)
               {
                   using (Html.BeginForm())
                   { %>
            <input type="text" id="content" name="content" />
            <input type="submit" value="Post" />
            <%     }
               } %>
            <ul id="twitter_update_list">
                <li id="loading"><img src="/Content/Life/loading.gif" alt="loading" />loading... </li>
            </ul>
        </div>
    </div>
    <script type="text/javascript" src="/Content/Life/blogger.js"></script>
    <script type="text/javascript" src="http://twitter.com/statuses/user_timeline/flankerfc.json?callback=twitterCallback2&amp;count=20"></script>
</asp:Content>

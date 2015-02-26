<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Game/game.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="main">
        <embed src="http://player.youku.com/player.php/sid/XOTAzOTM0ODg=/v.swf" quality="high"
            width="480" height="400" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"></embed>
        <div id="gameName">
            <span>Call of Duty 4: Modern Warfare</span>
            <span>使命召唤4：现代战争</span>
        </div>
    </div>
</asp:Content>

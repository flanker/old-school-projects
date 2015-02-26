<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<flankerbase.Models.Music.PlaylistModel>" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Music/music.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="main">
        <% if (Model.PlayerType == flankerbase.Models.Music.PlayerType.Local)
           { %>
        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="400" height="360"
            id="mp3player" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0">
            <param name="movie" value="/Content/Music/mp3player.swf" />
            <param name="flashvars" value="config=/Content/Music/config.xml&file=../GetList/<%= Model.LinkName %>" />
            <embed src="/Content/Music/mp3player.swf" width="400" height="360" name="mp3player"
                flashvars="config=/Content/Music/config.xml&file=../GetList/<%= Model.LinkName %>"
                type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
        </object>
        <%}
           else
           { %>
        <object id="Player" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" width="400"
            height="260">
            <param name="autoStart" value="true" />
            <param name="uiMode" value="full" />
            <param name="url" value="<%= Model.ListName %>" />
            <embed type="application/x-mplayer2" pluginspage="http://microsoft.com/windows/mediaplayer/en/download/"
                id="WM" width="400" height="260" autosize="1" autostart="1" clicktoplay="1" displaysize="0"
                enablecontextmenu="1" enablefullscreencontrols="0" enabletracker="0" mute="0"
                playcount="1" showcontrols="1" showaudiocontrols="1" showdisplay="1" showpositioncontrols="1"
                showstatusbar="1" showtracker="1" src="<%= Model.ListName %>">
	        </embed>
        </object>
        <p id="out">music by <a title="100hitz.com" href="http://www.100hitz.com">100hitz.com</a></p>
        <%} %>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Google.GData.Photos.PicasaEntry>>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    ViewPage1
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ViewPage1</h2>
    <ul>
        <% foreach (var item in Model)
           { %>
        <li>
            <p>IsPhoto:
                <%= Html.Encode(item.IsPhoto) %>
            </p>
            <p>IsComment:
                <%= Html.Encode(item.IsComment) %>
            </p>
            <p>IsAlbum:
                <%= Html.Encode(item.IsAlbum) %>
            </p>
            <p>IsTag:
                <%= Html.Encode(item.IsTag) %>
            </p>
            <p>Etag:
                <%= Html.Encode(item.Etag) %>
            </p>
            <p>XmlName:
                <%= Html.Encode(item.XmlName) %>
            </p>
            <p>FeedUri:
                <%= Html.Encode(item.FeedUri) %>
            </p>
            <p>Updated:
                <%= Html.Encode(String.Format("{0:g}", item.Updated)) %>
            </p>
            <p>Published:
                <%= Html.Encode(String.Format("{0:g}", item.Published)) %>
            </p>
            <p>IsDraft:
                <%= Html.Encode(item.IsDraft) %>
            </p>
            <p>ReadOnly:
                <%= Html.Encode(item.ReadOnly) %>
            </p>
            <p>Dirty:
                <%= Html.Encode(item.Dirty) %>
            </p>
            <p>Language:
                <%= Html.Encode(item.Language) %>
            </p>
            <p>ProtocolMajor:
                <%= Html.Encode(item.ProtocolMajor) %>
            </p>
            <p>ProtocolMinor:
                <%= Html.Encode(item.ProtocolMinor) %>
            </p>
            <p>
                <img src="<%= Html.Encode(item.Media.Thumbnails[0].Attributes["url"].ToString())%>" />
            </p>
        </li>
        <% } %>
    </ul>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase.Models.TwitterDTO>>" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">我的推特</asp:Content>
<asp:Content ID="InHead" ContentPlaceHolderID="InHeadContent" runat="server">
    <%--<link href="/Content/Twitter/Main.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="InPage" ContentPlaceHolderID="InPageContent" runat="server">
    <div class="large-page">
        <h2><a href="http://twitter.com/#!/flankerfc" title="flankerfc">follow 我</a></h2>
        <div class="large-page-part">
            <% foreach (var item in Model)
               { %>
            <div class="entry">
                <div class="entry-info">
                    <%= Html.Encode(item.CreatedAt) %> via <%= item.Source %>
                </div>
                <div class="entry-content-wrap">
                    <div class="entry-content">
                        <%= Html.Encode(item.Text) %>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>

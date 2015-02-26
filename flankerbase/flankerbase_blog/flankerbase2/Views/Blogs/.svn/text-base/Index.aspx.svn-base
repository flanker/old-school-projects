<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<flankerbase2.Models.Blog>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    flanker base - blogs
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="blogs">
        <% foreach (var blog in Model)
           { %>
        <div class="blog-entry">
            <h2 class="blog-entry-title">
                <%= Html.RouteLink(Html.Encode(blog.Title), "Blog", new { key = blog.Code }, new { @class = "highContrast" }) %>
            </h2>
            <div class="blog-entry-createdat highContrast">
                <%= Html.Encode(String.Format("{0:F}", blog.Created_at)) %>
            </div>
            <div class="blog-entry-tools">
                <%= Html.ActionLink("Post a Comment", "Details", new { key = blog.Code }, new { @class = "highContrast" })%>
                <%= Html.ActionLink("Edit", "Edit", new { key = blog.Code }, new { @class = "highContrast" })%>
            </div>
            <div class="blog-entry-content-wrap">
                <div class="blog-entry-content">
                    <%= Html.Encode(blog.Content) %>
                </div>
            </div>
        </div>
        <% } %>
    </div>
    <div>
        <%= Html.Paginate() %>
    </div>
</asp:Content>

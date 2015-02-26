<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<flankerbase2.Models.Blog>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    flanker base -
    <%= Html.Encode(Model.Title) %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blog-entry">
        <h2 class="blog-entry-title">
            <%= Html.RouteLink(Html.Encode(Model.Title), "Blog", new { key = Model.Code }, new { @class = "highContrast" })%>
        </h2>
        <div class="blog-entry-createdat highContrast">
            <%= Html.Encode(String.Format("{0:g}", Model.Created_at))%>
        </div>
        <div class="blog-entry-tools">
            <%= Html.ActionLink("Post a Comment", "Details", new { key = Model.Code }, new { @class = "highContrast" })%>
            <%= Html.ActionLink("Edit", "Edit", new { key = Model.Code }, new { @class = "highContrast" })%>
        </div>
        <div class="blog-entry-content-wrap">
            <div class="blog-entry-content">
                <%= Html.Encode(Model.Content)%>
            </div>
        </div>
        <% Html.RenderPartial("CommentList", Model.Comments); %>
        <% Html.RenderPartial("CommentForm", ViewData["comment"]); %>
    </div>
</asp:Content>

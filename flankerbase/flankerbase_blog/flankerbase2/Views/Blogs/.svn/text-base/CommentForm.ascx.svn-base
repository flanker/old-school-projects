<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<flankerbase2.Models.Comment>" %>
<%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
<% using (Html.BeginForm("CommentCreate", "Blogs"))
   {%>
<p>
    <label for="Name">Name:</label>
    <%= Html.TextBox("Name") %>
    <%= Html.ValidationMessage("Name", "*") %>
</p>
<p>
    <label for="Email">Email:</label>
    <%= Html.TextBox("Email") %>
    <%= Html.ValidationMessage("Email", "*") %>
</p>
<p>
    <label for="Content">Content:</label>
    <%= Html.TextBox("Content") %>
    <%= Html.ValidationMessage("Content", "*") %>
</p>
<p>
    <%= Html.Hidden("BlogID", Model.BlogID) %>
    <input type="submit" value="Create" />
</p>
<% } %>

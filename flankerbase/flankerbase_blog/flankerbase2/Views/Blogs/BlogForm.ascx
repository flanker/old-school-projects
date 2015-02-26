<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<flankerbase2.Models.Blog>" %>
<div class="content-box-wrap">
    <div class="content-box">
        <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
        <% using (Html.BeginForm())
           {%>
        <p>
            <label for="Code">Code:</label>
            <%= Html.TextBox("Code", Model.Code) %>
            <%= Html.ValidationMessage("Code", "*") %>
        </p>
        <p>
            <label for="Title">Title:</label>
            <%= Html.TextBox("Title", Model.Title)%>
            <%= Html.ValidationMessage("Title", "*") %>
        </p>
        <p>
            <label for="Content">Content:</label>
            <%= Html.TextArea("Content", Model.Content, new { rows = 8 })%>
            <%= Html.ValidationMessage("Content", "*") %>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
        <% } %>
    </div>
</div>

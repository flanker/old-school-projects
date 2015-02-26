<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<flankerbase.Models.Todo>" %>
<li><%= Html.Encode(Model.Description) %>
</li>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<flankerbase.Models.TodoDTO>" %>
<div id="process">
    <p id="process-title">
        完成 / 总计</p>
    <p id="process-content">
        <span id="process-finished"><%= Model.Process.AllFinishCount %></span> / <span id="process-total">
            <%= Model.Process.AllCount%></p>
    </span>
    <div id="process-bar">
        <div style="width: <%= Model.Process.Percent %>; min-width: <%= Model.Process.Percent %>;">
        </div>
    </div>
</div>
<div id="todos-outter-wrapper">
    <div id="todos-wrapper">
        <div id="todos-innner-wrapper">
            <ul id="todos">
                <% foreach (var item in Model.Todos)
                   {
                       Html.RenderPartial("aTodo", item);
                   } %>
            </ul>
        </div>
    </div>
</div>

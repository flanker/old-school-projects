<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<flankerbase.Models.Todo>" %>
<li id="<%= "item-" + Model.ID %>">
    <div class="item-desc">
        <% if (Model.IsFinished)
           { %>
        <img src="/Content/Todo/Images/heart.png" alt="已完成" />
        <% } %>
        <%= Html.Encode(Model.Description) %></div>
    <div class="item-buttons">
        <%= Ajax.ActionLink("完成", "Finish", new { ID = Model.ID }, 
            new AjaxOptions 
            {
                Confirm = "确认完成了吗?\\n完成了的任务将不能再修改.",
                HttpMethod = "Post",
                UpdateTargetId= "todos-content",
                InsertionMode= InsertionMode.Replace,
                OnSuccess = "finishSuccess",
                OnFailure = "ajaxFailure"
            }, new { title = "完成", @class = "check" })
        %>
        <%= Ajax.ActionLink("删除", "Delete", new { ID = Model.ID }, 
            new AjaxOptions 
            {
                Confirm = "你确定要销毁罪证吗?",
                HttpMethod = "Post",
                UpdateTargetId = "todos-content",
                InsertionMode = InsertionMode.Replace,
                OnSuccess = "deleteSuccess",
                OnFailure = "ajaxFailure"
            }, new { title = "删除", @class = "delete" })
        %>
    </div>
</li>

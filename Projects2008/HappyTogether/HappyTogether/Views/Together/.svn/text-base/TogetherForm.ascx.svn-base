<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.TogetherFormViewModel>" %>
<%= Html.ValidationSummary("修改失败。请修改错误并重试。")%>
<% using (Html.BeginForm())
   {%>
<div id="togetherDiv">
    <p>
        <label for="Title">活动名称</label>
        <%= Html.TextBox("Title", Model.Together.Title) %>
        <%= Html.ValidationMessage("Title", "*") %>
    </p>
    <p>
        <label for="TogetherType">活动类型</label>
        <%= Html.DropDownList("TogetherType", Model.TogetherTypes)%>
        <%= Html.ValidationMessage("TogetherType", "*")%>
    </p>
    <p>
        <label for="StartDate">时间</label>
        <%= Html.TextBox("StartDate", String.Format("{0:g}", Model.Together.StartDate), new { @class = "datepicker" })%>
        <%= Html.ValidationMessage("StartDate", "*")%>
    </p>
    <p>
        <label for="Description">描述：</label>
        <%= Html.TextArea("Description", Model.Together.Description) %>
        <%= Html.ValidationMessage("Description", "*") %>
    </p>
    <p>
        <label for="Address">地点：</label>
        <%= Html.TextBox("Address", Model.Together.Address) %>
        <%= Html.ValidationMessage("Address", "*") %>
    </p>
    <p>
        <label for="ContactPhone">联系电话：</label>
        <%= Html.TextBox("ContactPhone", Model.Together.ContactPhone)%>
        <%= Html.ValidationMessage("ContactPhone", "*") %>
    </p>
    <p>
        <label for="FeeType">费用类型</label>
        <%= Html.DropDownList("FeeType", Model.FeeTypes)%>
        <%= Html.ValidationMessage("FeeType", "*")%>
    </p>
    <p>
        <label for="Fee">费用说明</label>
        <%= Html.TextBox("Fee", Model.Together.Fee)%>
        <%= Html.ValidationMessage("Fee", "*")%>
    </p>
    <p>
        <%= Html.Hidden("Latitude", Model.Together.Latitude)%>
        <%= Html.Hidden("Longitude", Model.Together.Longitude)%>
    </p>
    <p>
        <input type="submit" value="保存" />
    </p>
</div>
<div id="mapDiv">
    <% Html.RenderPartial("Map", Model.Together); %>
</div>
<script type="text/javascript">
    $(document).ready(function() {
        $("#Address").blur(function(evt) {
            $("#Latitude").val("");
            $("#Longitude").val("");
            var address = jQuery.trim($("#Address").val());
            if (address.length < 1)
                return;
            FindAddressOnMap(address);
        });
    });
</script>
<% } %>
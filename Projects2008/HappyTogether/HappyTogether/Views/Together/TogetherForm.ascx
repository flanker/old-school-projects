<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HappyTogether.Models.TogetherFormViewModel>" %>
<%= Html.ValidationSummary("�޸�ʧ�ܡ����޸Ĵ������ԡ�")%>
<% using (Html.BeginForm())
   {%>
<div id="togetherDiv">
    <p>
        <label for="Title">�����</label>
        <%= Html.TextBox("Title", Model.Together.Title) %>
        <%= Html.ValidationMessage("Title", "*") %>
    </p>
    <p>
        <label for="TogetherType">�����</label>
        <%= Html.DropDownList("TogetherType", Model.TogetherTypes)%>
        <%= Html.ValidationMessage("TogetherType", "*")%>
    </p>
    <p>
        <label for="StartDate">ʱ��</label>
        <%= Html.TextBox("StartDate", String.Format("{0:g}", Model.Together.StartDate), new { @class = "datepicker" })%>
        <%= Html.ValidationMessage("StartDate", "*")%>
    </p>
    <p>
        <label for="Description">������</label>
        <%= Html.TextArea("Description", Model.Together.Description) %>
        <%= Html.ValidationMessage("Description", "*") %>
    </p>
    <p>
        <label for="Address">�ص㣺</label>
        <%= Html.TextBox("Address", Model.Together.Address) %>
        <%= Html.ValidationMessage("Address", "*") %>
    </p>
    <p>
        <label for="ContactPhone">��ϵ�绰��</label>
        <%= Html.TextBox("ContactPhone", Model.Together.ContactPhone)%>
        <%= Html.ValidationMessage("ContactPhone", "*") %>
    </p>
    <p>
        <label for="FeeType">��������</label>
        <%= Html.DropDownList("FeeType", Model.FeeTypes)%>
        <%= Html.ValidationMessage("FeeType", "*")%>
    </p>
    <p>
        <label for="Fee">����˵��</label>
        <%= Html.TextBox("Fee", Model.Together.Fee)%>
        <%= Html.ValidationMessage("Fee", "*")%>
    </p>
    <p>
        <%= Html.Hidden("Latitude", Model.Together.Latitude)%>
        <%= Html.Hidden("Longitude", Model.Together.Longitude)%>
    </p>
    <p>
        <input type="submit" value="����" />
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
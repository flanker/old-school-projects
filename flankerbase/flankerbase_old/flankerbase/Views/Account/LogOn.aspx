<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LogOn</title>
</head>
<body>
    <h2>��¼</h2>
    <p>����������û��������롣</p>
    <%= Html.ValidationSummary("��¼ʧ�ܡ����޸Ĵ������ԡ�") %>
    <% using (Html.BeginForm())
       { %>
    <div>
        <fieldset><legend>�˻���Ϣ</legend>
            <p>
                <label for="username">�û�����</label>
                <%= Html.TextBox("username") %>
                <%= Html.ValidationMessage("username") %>
            </p>
            <p>
                <label for="password">���룺</label>
                <%= Html.Password("password") %>
                <%= Html.ValidationMessage("password") %>
            </p>
            <p>
                <input type="submit" value="��¼" />
            </p>
        </fieldset>
    </div>
    <% } %>
</body>
</html>

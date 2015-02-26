<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="New.aspx.cs" Inherits="DakkaWeb.Views.Employee.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        Ext.onReady(function() {

            var newForm = new Ext.FormPanel({
                labelWidth: 75,
                url: 'New',
                method: 'post',
                frame: true,
                bodyStyle: 'padding:5px 5px 0',
                width: 350,
                defaults: { width: 230 },
                defaultType: 'textfield',
                renderTo: 'newDiv',
                monitorValid: true,

                items: [
                    { fieldLabel: 'Code', name: 'Code', allowBlank: false },
                    { fieldLabel: 'Name', name: 'Name', allowBlank: false },
                    { fieldLabel: 'Email', name: 'Email', allowBlank: false },
                    { fieldLabel: 'Dept', name: 'Dept', allowBlank: true }
                ],

                buttons: [
                    { text: "OK", handler: AddNew, formBind: true },
                    { text: "Reset", handler: reset }
                ]
            });

            function AddNew() {
                if (newForm.getForm().isValid())        //表单数据进行验证
                {
                    newForm.getForm().submit({          //提交表单
                        waitMsg: 'saving...',           //表单提交等待过程中,出现的等待字符
                        success: function(re, v) {              //表单提交成功后,调用的函数.参数分为两个,一个是提交的表单对象,另一个是JSP返回的参数值对象
                            var jsonobject = Ext.util.JSON.decode(v.response.responseText);   //将返回的JSON数据转换成JSON对象,转换失败即报错.
                            Ext.Msg.alert("Success", jsonobject.msg);                                    // 用JSON对象获取JSON数据的值
                            newForm.getForm().reset();           //表单中所有数据置空
                        },
                        failure: function(re, v) {
                            var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                            Ext.Msg.alert("Error", jsonobject.msg);      //返回失败
                            newForm.items[0].focus();
                        }
                    });
                }
            }

            function reset() {
                newForm.getForm().reset();
            }
        });
    </script>

    <div id="newDiv">
    </div>
</asp:Content>

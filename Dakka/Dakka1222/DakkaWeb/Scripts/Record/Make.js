// Record/Make
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />
/// <reference path="../Shared/EmployeeRefField.js" />


Ext.onReady(function() {

    var EmployeeCodeRef = new Ext.form.EmployeeRefField({
        id: 'EmployeeCode',
        fieldLabel: 'Employee Code',
        name: 'EmployeeCode'
    });

    var WorkCalendarCodeRef = new Ext.form.WorkCalendarRefField({
        id: 'WorkCalendarCode',
        fieldLabel: 'WorkCalendar Code',
        name: 'WorkCalendarCode'
    });

    var formMain = new Ext.FormPanel({
        renderTo: 'formMain',
        url: 'DoMake',
        labelAlign: 'right',
        labelWidth: 120,
        method: 'post',
        frame: true,
        bodyStyle: 'padding:5px 5px 0',
        width: 'auto',
        height: 'auto',
        defaults: { width: 200, autoHeight: true },
        defaultType: 'textfield',
        buttonAlign: 'left',

        items: [EmployeeCodeRef,
                WorkCalendarCodeRef,
                { id: 'FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d', allowBlank: false },
                { id: 'ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d', allowBlank: false}],

        buttons: [{ text: "Make", handler: FormMain_Make_Click },
            { text: "Reset", handler: FormMain_Reset_Click}]

    });

    // formMain上的事件处理 ****************************************************

    function FormMain_Make_Click() {
        if (formMain.getForm().isValid())        //表单数据验证
        {
            formMain.getForm().submit({          //提交表单
                waitMsg: 'making records...',
                success: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    Ext.flanker.msg("Success", jsonobject.msg);
                    formMain.getForm().reset();
                },
                failure: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    Ext.Msg.alert("Error", jsonobject.msg);
                    formMain.items[0].focus();
                }
            });
        }
    }

    function FormMain_Reset_Click() {
        formMain.getForm().reset();
    }

});
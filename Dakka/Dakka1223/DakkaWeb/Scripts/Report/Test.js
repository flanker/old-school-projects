// Report/Test
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../Shared/EmployeeRefField.js" />


Ext.onReady(function() {

    var EmployeeCodeRef = new Ext.form.EmployeeRefField({
        id: 'EmployeeCode',
        fieldLabel: 'Employee Code',
        name: 'EmployeeCode'
    });

    var formMain = new Ext.FormPanel({
        renderTo: 'formMain',
        url: 'Test',
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

        onSubmit: Ext.emptyFn,
        submit: function() {
            this.getEl().dom.action = 'Test',
                    this.getEl().dom.method = 'post',
                    this.getEl().dom.submit();
        },

        items: [EmployeeCodeRef,
                { id: 'FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d', allowBlank: false },
                { id: 'ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d', allowBlank: false}],

        buttons: [{ text: "Report", handler: FormMain_Report_Click },
            { text: "Reset", handler: FormMain_Reset_Click}]

    });

    // formMain上的事件处理 ****************************************************

    function FormMain_Report_Click() {
        formMain.getForm().submit();
    }

    function FormMain_Reset_Click() {
        formMain.getForm().reset();
    }

});
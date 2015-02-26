// Account/Login
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.BLANK_IMAGE_URL = '../../Content/Images/s.gif';

Ext.onReady(function() {

    Ext.QuickTips.init();

    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    var simple = new Ext.FormPanel({
        labelWidth: 75, // label settings here cascade unless overridden
        url: 'Login',
        method: 'post',
        frame: true,
        title: 'Login Form',
        bodyStyle: 'padding:5px 5px 0',
        width: 350,
        defaults: { width: 230 },
        defaultType: 'textfield',
        renderTo: 'loginDiv',
        monitorValid: true,

        onSubmit: Ext.emptyFn,
        submit: function() {
            this.getEl().dom.action = 'Login',
                    this.getEl().dom.method = 'post',
                    this.getEl().dom.submit();
        },

        items: [{ id: 'U', fieldLabel: 'User name', name: 'username', allowBlank: false },
            { id: 'P', fieldLabel: 'Password', name: 'password', inputType: 'password', allowBlank: false },
            { fieldLabel: '', name: 'rememberMe', xtype: 'checkbox', boxLabel: 'Remember me?', labelSeparator: '' },
            { name: 'returnUrl', value: Ext.get('returnUrl').getValue(), xtype: 'hidden'}],

        buttons: [{ text: "OK", handler: login, formBind: true },
            { text: "Reset", handler: reset}],

        keys: [{ key: Ext.EventObject.ENTER, fn: login, scope: this}]
    });

    function login() {
        simple.form.submit();
    }
    function reset() {
        simple.form.reset();
    }

    Ext.getCmp('U').setValue('admin');
    Ext.getCmp('P').setValue('123456');

});
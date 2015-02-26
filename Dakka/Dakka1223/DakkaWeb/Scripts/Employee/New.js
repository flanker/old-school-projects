// Employee/New
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    var formItems = [{ id: 'Code', fieldLabel: 'Code', name: 'Code', allowBlank: false },
              { id: 'Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
              { id: 'Email', fieldLabel: 'Email', name: 'Email', allowBlank: false, vtype: 'email' },
              { id: 'Dept', fieldLabel: 'Dept', name: 'Dept', allowBlank: true}];

    var panelMain = new Ext.NewPanel({
        formItems: formItems,
        gridItems: null
    });

});
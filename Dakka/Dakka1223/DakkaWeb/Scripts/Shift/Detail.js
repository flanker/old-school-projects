// Shift/Detail
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    var ShiftTypeComboBox = new Ext.form.ExComboBox({
        id: 'ShiftType',
        fieldLabel: 'ShiftType',
        name: 'ShiftType',
        ExData: ['Normal', 'Other']
    });

    var formItems = [{ id: 'Code', fieldLabel: 'Code', name: 'Code', allowBlank: false, vtype: 'alphanum' },
                { id: 'Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { id: 'Description', xtype: 'textarea', fieldLabel: 'Description', name: 'Description', allowBlank: false },
                ShiftTypeComboBox];

    var PointTypeComboBox = new Ext.form.ExComboBox({
        fieldLabel: 'PointType',
        name: 'PointType',
        ExData: ['In', 'Out']
    });

    var gridItems = [{ header: "IndexNumber", width: 100, dataIndex: 'IndexNumber', editor: new Ext.form.NumberField() },
            { header: "Name", width: 120, dataIndex: 'Name', editor: new Ext.form.TextField() },
            { header: "PointTime(HH:MM:SS)", width: 120, dataIndex: 'PointTime', editor: new Ext.form.TextField() },
            { header: 'Before', width: 80, dataIndex: 'Before', editor: new Ext.form.NumberField() },
            { header: 'After', width: 80, dataIndex: 'After', editor: new Ext.form.NumberField() },
            { header: "PointType", width: 80, dataIndex: 'PointType', editor: PointTypeComboBox },
            { header: "Description", width: 160, dataIndex: 'Description', editor: new Ext.form.TextField()}];

    var panelMain = new Ext.DetailPanel({
        processID: Ext.get('processID').getValue(),
        formItems: formItems,
        gridItems: gridItems
    });

    // panelMain.LoadData();
});
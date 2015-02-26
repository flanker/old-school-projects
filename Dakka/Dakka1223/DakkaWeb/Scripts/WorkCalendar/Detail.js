// WorkCalendar/Detail
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    var formItems = [{ id: 'Code', fieldLabel: 'Code', name: 'Code', allowBlank: false, vtype: 'alphanum' },
                { id: 'Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { id: 'Description', xtype: 'textarea', fieldLabel: 'Description', name: 'Description', allowBlank: false },
                { id: 'FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d' },
                { id: 'ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d'}];

    var RuleTypeComboBox = new Ext.form.ExComboBox({
        fieldLabel: 'RuleType',
        name: 'RuleType',
        ExData: ['Week', 'Month', 'Year', 'Date']
    });

    var IsWorkDayComboBox = new Ext.form.ExComboBox({
        fieldLabel: 'Week',
        name: 'Week',
        ExData: ['True', 'False']
    });

    var WeekComboBox = new Ext.form.ExComboBox({
        fieldLabel: 'Week',
        name: 'Week',
        ExData: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
    });

    var gridItems = [{ header: "RuleType", width: 70, dataIndex: 'RuleType', editor: RuleTypeComboBox },
        { header: "IsWorkDay", width: 70, dataIndex: 'IsWorkDay', editor: IsWorkDayComboBox },
        { header: "Week", width: 70, dataIndex: 'Week', editor: WeekComboBox },
        { header: "Year", width: 50, dataIndex: 'Year', editor: new Ext.form.NumberField() },
        { header: "Month", width: 50, dataIndex: 'Month', editor: new Ext.form.NumberField() },
        { header: "Day", width: 50, dataIndex: 'Day', editor: new Ext.form.NumberField() },
        { header: "Number", width: 50, dataIndex: 'Number', editor: new Ext.form.NumberField() },
        { header: "ShiftDef", width: 70, dataIndex: 'ShiftDef', editor: new Ext.form.ShiftDefRefField()}];

    var panelMain = new Ext.DetailPanel({
        processID: Ext.get('processID').getValue(),
        formItems: formItems,
        gridItems: gridItems
    });

    panelMain.LoadData();
    
});
// Record/Search
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    // 保存数据的变量 全聚德
    var processData;

    // example of custom renderer function
    function change(val) {
        if (val == 'OK') {
            return '<span style="color:green;">' + val + '</span>';
        } else if (val == 'Exception') {
            return '<span style="color:red;">' + val + '</span>';
        }
        return val;
    }

    // 卡片 ***************************************************************

    var EmployeeCodeRef = new Ext.form.EmployeeRefField({
        id: 'formMain_EmployeeCode',
        fieldLabel: 'Employee Code',
        name: 'EmployeeCode'
    });

    // 卡片form
    var formMain = new Ext.FormPanel({
        labelAlign: 'right',
        labelWidth: 100,
        frame: true,
        bodyStyle: 'padding:5px 5px 0',
        width: 'auto',
        height: 'auto',
        defaults: { width: 200, autoHeight: true },
        defaultType: 'textfield',
        monitorValid: true,
        buttonAlign: 'left',

        items: [EmployeeCodeRef,
                { id: 'formMain_FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d' },
                { id: 'formMain_ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d'}],
        // { id: 'ShiftType', fieldLabel: 'ShiftType', name: 'ShiftType', allowBlank: true}

        buttons: [{ text: "Search", handler: FormMain_Search_Click },
            { text: "Reset", handler: FormMain_Reset_Click}]

    });

    // Grid ***************************************************************

    var TestRecord = Ext.data.Record.create([
           { name: 'WorkPoint', type: 'string' },
           { name: 'PointType', type: 'string' },
           { name: 'Status', type: 'string' }
      ]);

    var ds = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({
            url: 'GetRecords',
            method: 'POST'
        }),
        reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root' },
                    [{ name: 'WorkPoint' }, { name: 'PointType' }, { name: 'Status'}])
    });

    ds.on('beforeload', function(store) {
        store.baseParams = {
            Employee: Ext.getCmp('formMain_EmployeeCode').getValue(),
            FromDate: Ext.getCmp('formMain_FromDate').getRawValue(),
            ToDate: Ext.getCmp('formMain_ToDate').getRawValue()
        };
    })

    // 创建Grid选择框列
    var sm = new Ext.grid.CheckboxSelectionModel();

    // 创建Grid列
    var cm = new Ext.grid.ColumnModel([
    // new Ext.grid.RowNumberer(),
        sm,
        { header: "WorkPoint", width: 120, dataIndex: 'WorkPoint', sortable: true },
        { header: "PointType", width: 100, dataIndex: 'PointType', sortable: true },
        { header: "Status", width: 100, dataIndex: 'Status', renderer: change, sortable: true }
    ]);

    var gridMain = new Ext.grid.GridPanel({
        ds: ds,
        cm: cm,
        sm: sm,
        stripeRows: true,
        height: 500,
        loadMask: true,

        // 底部Bar: 翻页
        bbar: new Ext.PagingToolbar({
            pageSize: 20,
            store: ds,
            displayInfo: true,
            displayMsg: 'From {0} to {1} , total: {2}',
            emptyMsg: "No record"
        })
    });

    // 主Panel ***************************************************************

    var panelMain = new Ext.Panel({
        renderTo: 'divMain',
        items: [formMain, gridMain]
    });

    // From事件处理 ***************************************************************

    function FormMain_Search_Click() {
        ds.load({
            params: {
                start: 0,
                limit: 20
            },
            callback: function() {
                Ext.flanker.msg('Load', 'Load success!');
            }
        });
        gridMain.getSelectionModel().selectFirstRow();

    }

    function FormMain_Reset_Click() {

    }


});
// Shift/Detail
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />


Ext.onReady(function() {
    var processID = Ext.get('processID').getValue();

    // 保存数据的变量 全聚德
    var processData;

    // 卡片 ***************************************************************

    // ShiftType选择框
    var formMain_ShiftType = new Ext.form.ComboBox({
        fieldLabel: 'ShiftType',
        name: 'ShiftType',
        allowBlank: true,
        mode: 'local',
        readOnly: true,
        triggerAction: 'all',
        emptyText: 'Select...',
        store: new Ext.data.SimpleStore({
            fields: ['value', 'text'],
            data: [['Normal', 'Normal'], ['Other', 'Other']]     // 选择框的数据(静态值)
        }),
        valueField: 'value',
        displayField: 'text'
    });

    // 卡片form
    var formMain = new Ext.FormPanel({
        labelAlign: 'right',
        labelWidth: 75,
        url: 'New',
        method: 'post',
        frame: true,
        bodyStyle: 'padding:5px 5px 0',
        width: 'auto',
        height: 'auto',
        defaults: { width: 200, autoHeight: true },
        defaultType: 'textfield',
        monitorValid: true,
        buttonAlign: 'left',

        items: [{ id: 'formMain_Code', fieldLabel: 'Code', name: 'Code', allowBlank: false },
                { id: 'formMain_Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { id: 'formMain_Description', xtype: 'textarea', fieldLabel: 'Description', name: 'Description', allowBlank: false },
                formMain_ShiftType]
        // { id: 'ShiftType', fieldLabel: 'ShiftType', name: 'ShiftType', allowBlank: true}

    });


    // Grid ***************************************************************

    var TestRecord = Ext.data.Record.create([
           { name: 'IndexNumber', type: 'int' },
           { name: 'Name', type: 'string' },
           { name: 'PointTime', type: 'string' },
           { name: 'PointType', type: 'string' },
           { name: 'Description', type: 'string' }
      ]);

    //var ds = new Ext.data.JsonStore({
    //    data: [{ ID: null, Code: null, Name: null, Email: null, Dept: null}],
    //    //data: [{ "IndexNumber": 10, "Name": "上班", "PointTime": "\/Date(1226793600000)\/", "PointType": 1, "Description": null }, { "IndexNumber": 20, "Name": "下班", "PointTime": "\/Date(1226808000000)\/", "PointType": 2, "Description": null}],
    //    fields: ["IndexNumber", "Name", 'PointTime', "PointType", 'Description']
    //});

    var ds = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({ url: 'GetPoints?ID=' + processID, method: 'GET' }),
        reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root' },
            [{ name: 'IndexNumber' }, { name: 'Name' }, { name: 'PointTime' }, { name: 'PointType' }, { name: 'Description'}])
    });
    ds.load();

    var PointTypeComboBox = new Ext.form.ComboBox({
        fieldLabel: 'PointType',  //UI标签名称
        name: 'PointType',   //作为form提交时传送的参数
        allowBlank: true,  //是否允许为空
        mode: 'local',      //数据模式,local为本地模式
        readOnly: true,     //是否只读
        triggerAction: 'all',  //显示所有下列数.必须指定为'all'
        emptyText: 'Select...',
        store: new Ext.data.SimpleStore({  //填充的数据
            fields: ['value', 'text'],
            data: [['In', 'In'], ['Out', 'Out']]
        }),
        valueField: 'value',  //传送的值
        displayField: 'text',  //UI列表显示的文本

        renderer: function(v, m, r) { return r.get('value'); },
        listeners: { select: function(combo, r, i) { if (r) r.set('value', this.getRawValue()); } }

    });

    // 创建Grid选择框列
    var sm = new Ext.grid.CheckboxSelectionModel();

    // 创建Grid列
    var cm = new Ext.grid.ColumnModel([
    // new Ext.grid.RowNumberer(),
        sm,
        { header: "IndexNumber", width: 100, dataIndex: 'IndexNumber', sortable: true, editor: new Ext.form.TextField({}) },
        { header: "Name", width: 120, dataIndex: 'Name', sortable: true, editor: new Ext.form.TextField({}) },
        { header: "PointTime(HH:MM:SS)", width: 120, dataIndex: 'PointTime', sortable: true, editor: new Ext.form.TextField({}) },
        { header: "PointType", width: 160, dataIndex: 'PointType', sortable: true, editor: PointTypeComboBox },
        { header: "Description", width: 160, dataIndex: 'Description', sortable: true, editor: new Ext.form.TextField({}) }
    ]);

    var gridMain = new Ext.grid.EditorGridPanel({
        ds: ds,
        cm: cm,
        sm: sm,
        stripeRows: true,
        height: 350,
        clicksToEdit: 1,

        tbar: [{ text: 'Add', tooltip: 'Add new record', iconCls: 'add', handler: GridMain_Add_Click },
               { text: 'Remove', tooltip: 'Remove selected record', iconCls: 'remove', handler: GridMain_Remove_Click}]
    });

    // Grid上的右键关联菜单 ***************************************************

    gridMain.addListener('rowcontextmenu', rightClickFn);
    var rightClick = new Ext.menu.Menu({
        id: 'rightClickCont',
        items: [{ id: 'rMenu1', handler: GridMain_Add_Click, text: 'Add record'}]
    });

    function rightClickFn(grid, rowindex, e) {
        e.preventDefault();
        rightClick.showAt(e.getXY());
    }

    // 主Panel ***************************************************************

    var panelMain = new Ext.Panel({
        renderTo: 'divMain',
        items: [formMain, gridMain],

        // 首部Bar: 按钮
        tbar: new Ext.Toolbar({
            items: [{ id: 'ButtonSave', text: 'Save', tooltip: 'Save this data', iconCls: 'save', handler: FormMain_Save_Click },
                    '-',
                    { id: 'ButtonCancel', text: 'Cancel', tooltip: 'Cancel all changes', iconCls: 'cancel', handler: FormMain_Cancel_Click },
                    '-',
                    { id: 'ButtonReturn', text: 'Return', tooltip: 'Return to the list', iconCls: 'return', handler: FormMain_Return_Click },
                    '-',
                    { id: 'ButtonPageFirst', text: 'First', tooltip: 'First page', iconCls: 'pageFirst', handler: null },
                    '-',
                    { id: 'ButtonPagePrev', text: 'Prev', tooltip: 'Prev page', iconCls: 'pagePrev', handler: null },
                    '-',
                    { id: 'ButtonPageNext', text: 'Next', tooltip: 'Next page', iconCls: 'pageNext', handler: null },
                    '-',
                    { id: 'ButtonPageLast', text: 'Last', tooltip: 'Last page', iconCls: 'pageLast', handler: null}]
        })
    });

    // 表格的事件处理 ***************************************************************

    function GridMain_Add_Click() {
        var p = new TestRecord({
            IndexNumber: null,
            Name: null,
            PointTime: null,
            PointType: null,
            Description: null
        });
        gridMain.stopEditing();
        ds.add(p);
        gridMain.startEditing(0, 0);
    }

    function GridMain_Remove_Click() {
        var selectedRow = gridMain.getSelectionModel().getSelected();
        if (selectedRow) {
            ds.remove(selectedRow);
        }
    }

    // Form的事件处理 ***************************************************************

    function FormMain_Save_Click() {

        var dataSend = "{data: [";

        for (var i = 0, len = ds.getCount(); i < len; i++) {
            var rec = ds.getAt(i);
            dataSend += "{IndexNumber:'" + rec.get('IndexNumber') + "',"
                        + " Name:'" + rec.get('Name') + "',"
                        + " PointTime:'" + rec.get('PointTime') + "',"
                        + " PointType:'" + rec.get('PointType') + "',"
                        + " Description:'" + rec.get('Description') + "'"
                        + " }";
            if (i < len - 1)
                dataSend += ","
        }
        dataSend += "]}";
        //   dataSend = Ext.util.JSON.encode(dataSend);

        var code = Ext.getCmp('formMain_Code').getValue();
        var name = Ext.getCmp('formMain_Name').getValue();
        var description = Ext.getCmp('formMain_Description').getValue();
        var shiftType = formMain_ShiftType.getValue();

        var mark = new Ext.LoadMask(Ext.getBody(), { msg: "Updating..." });
        mark.show();

        Ext.Ajax.request({
            url: 'Update',
            method: 'POST',
            success: function(result, request) {
                mark.hide();
                Ext.flanker.showResult(result.responseText);  // 处理返回结果
            },
            failure: function(result, request) {
                mark.hide();
                var jsonobject = Ext.util.JSON.decode(result.responseText);
                Ext.Msg.alert("Error", jsonobject.msg);
            },
            params: {
                ID: processID,
                Code: code,
                Name: name,
                Description: description,
                ShiftType: shiftType,
                Points: dataSend
            }
        });
    }

    function FormMain_Cancel_Click() {

    }

    function FormMain_Return_Click() {
        window.location.href = "List";
    }


    // load数据 ***************************************************************

    // 发送ajax请求: 通过ID加载数据
    Ext.Ajax.request({
        url: 'GetByID',     // url
        method: 'GET',
        success: function(result, request) {
            processData = Ext.util.JSON.decode(result.responseText);    // 返回JSON
            Ext.flanker.msg("Success", 'load data success');

            // 给卡片form赋值
            Ext.getCmp('formMain_Code').setValue(processData.Code);
            Ext.getCmp('formMain_Name').setValue(processData.Name);
            Ext.getCmp('formMain_Description').setValue(processData.Description);
            formMain_ShiftType.setValue(processData.ShiftType);
        },
        failure: function(result, request) {
            var jsonobject = Ext.util.JSON.decode(result.responseText);
            Ext.Msg.alert("Error", jsonobject.msg);
        },
        params: {
            ID: processID       // 请求参数
        }
    });
});
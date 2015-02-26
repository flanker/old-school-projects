// Shift/New
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    // 卡片 ***************************************************************

    var ShiftTypeComboBox = new Ext.form.ComboBox({
        fieldLabel: 'ShiftType',  //UI标签名称
        name: 'ShiftType',   //作为form提交时传送的参数
        allowBlank: true,  //是否允许为空
        mode: 'local',      //数据模式,local为本地模式
        readOnly: true,     //是否只读
        triggerAction: 'all',  //显示所有下列数.必须指定为'all'
        emptyText: 'Select...',
        store: new Ext.data.SimpleStore({  //填充的数据
            fields: ['value', 'text'],
            data: [['Normal', 'Normal'], ['Normal', 'Other']]
        }),
        valueField: 'value',  //传送的值
        displayField: 'text'  //UI列表显示的文本
    });

    var formMain = new Ext.FormPanel({
        labelAlign: 'left',
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

        items: [{ id: 'Code', fieldLabel: 'Code', name: 'Code', allowBlank: false, vtype: 'alphanum' },
                { id: 'Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { id: 'Description', xtype: 'textarea', fieldLabel: 'Description', name: 'Description', allowBlank: false },
                ShiftTypeComboBox]
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

    var ds = new Ext.data.JsonStore({
        data: [{ ID: null, Code: null, Name: null, Email: null, Dept: null}],
        fields: ["IndexNumber", "Name", 'PointTime', "PointType", 'Description']
    });

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
            data: [['1', 'In'], ['2', 'Out']]
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
        { header: "IndexNumber", width: 100, dataIndex: 'IndexNumber', sortable: true, editor: new Ext.form.NumberField({}) },
        { header: "Name", width: 120, dataIndex: 'Name', sortable: true, editor: new Ext.form.TextField() },
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
                    { id: 'ButtonClean', text: 'Clean', tooltip: 'Clean all forms', iconCls: 'clean', handler: FormMain_Clean_Click },
                    { id: 'ButtonReturn', text: 'Return', tooltip: 'Return to the list', iconCls: 'return', handler: FormMain_Return_Click}]
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
        var m = ds.getModifiedRecords();
        if (m.length == 0) {
            return false;
        }
        var dataSend = "{data: ["
        for (var i = 0, len = m.length; i < len; i++) {
            dataSend += "{IndexNumber:'" + m[i].data['IndexNumber'] + "',"
                        + " Name:'" + m[i].data['Name'] + "',"
                        + " PointTime:'" + m[i].data['PointTime'] + "',"
                        + " PointType:'" + m[i].data['PointType'] + "',"
                        + " Description:'" + m[i].data['Description'] + "'"
                        + " }";
            if (i < len - 1)
                dataSend += ","
        }
        dataSend += "]}";
        //   dataSend = Ext.util.JSON.encode(dataSend);

        var code = formMain.getComponent('Code').getValue();
        var name = formMain.getComponent('Name').getValue();
        var description = formMain.getComponent('Description').getValue();
        var shiftType = ShiftTypeComboBox.getValue();

        var mark = new Ext.LoadMask(Ext.getBody(), { msg: "Saving..." });
        mark.show();

        Ext.Ajax.request({
            url: 'AddNew',
            method: 'POST',
            success: function(result, request) {
                mark.hide();
                var jsonobject = Ext.util.JSON.decode(result.responseText);
                Ext.flanker.msg("Success", jsonobject.msg);
            },
            failure: function(result, request) {
                mark.hide();
                var jsonobject = Ext.util.JSON.decode(result.responseText);
                Ext.Msg.alert("Error", jsonobject.msg);
            },
            params: {
                Code: code,
                Name: name,
                Description: description,
                ShiftType: shiftType,
                Points: dataSend
            }
        });

        mark.destroy();
    }

    function FormMain_Clean_Click() {

    }

    function FormMain_Return_Click() {
        window.location.href = "List";
    }
});
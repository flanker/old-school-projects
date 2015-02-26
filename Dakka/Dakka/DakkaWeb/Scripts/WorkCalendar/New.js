// WorkCalendar/New
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    // 卡片 ***************************************************************

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
                { id: 'FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d' },
                { id: 'ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d'}]
        // { id: 'ShiftType', fieldLabel: 'ShiftType', name: 'ShiftType', allowBlank: true}

    });

    // Grid ***************************************************************

    var TestRecord = Ext.data.Record.create([
           { name: 'RuleType', type: 'int' },
           { name: 'RuleValue', type: 'string' },
           { name: 'IsWorkDay', type: 'int' },
           { name: 'Number', type: 'int' },
           { name: 'ShiftDef', type: 'int' }
      ]);

    var ds = new Ext.data.JsonStore({
        data: [{ RuleType: null, IsWorkDay: null, Week: null, Year: null, Month: null, Day: null, Number: null, ShiftDef: null}],
        fields: ["RuleType", 'IsWorkDay', "Week", "Year", "Month", "Day", "Number", 'ShiftDef']
    });

    var RuleTypeComboBox = new Ext.form.ComboBox({
        fieldLabel: 'RuleType',  //UI标签名称
        name: 'RuleType',   //作为form提交时传送的参数
        allowBlank: true,  //是否允许为空
        mode: 'local',      //数据模式,local为本地模式
        readOnly: true,     //是否只读
        triggerAction: 'all',  //显示所有下列数.必须指定为'all'
        emptyText: 'Select...',
        store: new Ext.data.SimpleStore({  //填充的数据
            fields: ['value', 'text'],
            data: [['1', 'Week'], ['2', 'Month'], ['3', 'Year'], ['4', 'Date']]
        }),
        valueField: 'value',  //传送的值
        displayField: 'text'  //UI列表显示的文本
    });

    var IsWorkDayComboBox = new Ext.form.ComboBox({
        fieldLabel: 'Week',  //UI标签名称
        name: 'Week',   //作为form提交时传送的参数
        allowBlank: true,  //是否允许为空
        mode: 'local',      //数据模式,local为本地模式
        readOnly: true,     //是否只读
        triggerAction: 'all',  //显示所有下列数.必须指定为'all'
        store: new Ext.data.SimpleStore({  //填充的数据
            fields: ['value', 'text'],
            data: [['1', 'Yes'], ['2', 'No']]
        }),
        valueField: 'value',  //传送的值
        displayField: 'text'  //UI列表显示的文本
    });

    var WeekComboBox = new Ext.form.ComboBox({
        fieldLabel: 'Week',  //UI标签名称
        name: 'Week',   //作为form提交时传送的参数
        allowBlank: true,  //是否允许为空
        mode: 'local',      //数据模式,local为本地模式
        readOnly: true,     //是否只读
        triggerAction: 'all',  //显示所有下列数.必须指定为'all'
        emptyText: 'Select...',
        store: new Ext.data.SimpleStore({  //填充的数据
            fields: ['value', 'text'],
            data: [['1', 'Monday'], ['2', 'Tuesday'], ['3', 'Wednesday'], ['4', 'Thursday'], ['5', 'Friday'], ['6', 'Saturday'], ['7', 'Sunday']]
        }),
        valueField: 'value',  //传送的值
        displayField: 'text'  //UI列表显示的文本
    });

    // 创建Grid选择框列
    var sm = new Ext.grid.CheckboxSelectionModel();

    // 创建Grid列
    var cm = new Ext.grid.ColumnModel([
    // new Ext.grid.RowNumberer(),
        sm,
        { header: "RuleType", width: 100, dataIndex: 'RuleType', sortable: true, editor: RuleTypeComboBox },
        { header: "IsWorkDay", width: 30, dataIndex: 'IsWorkDay', sortable: true, editor: IsWorkDayComboBox },
        { header: "Week", width: 30, dataIndex: 'Week', sortable: true, editor: WeekComboBox },
        { header: "Year", width: 30, dataIndex: 'Year', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Month", width: 30, dataIndex: 'Month', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Day", width: 30, dataIndex: 'Day', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Number", width: 60, dataIndex: 'Number', sortable: true, editor: new Ext.form.NumberField() },
        { header: "ShiftDef", width: 60, dataIndex: 'ShiftDef', sortable: true, editor: new Ext.form.TextField() }
    ]);

    var gridMain = new Ext.grid.EditorGridPanel({
        ds: ds,
        cm: cm,
        sm: sm,
        stripeRows: true,
        height: 300,
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


    ["RuleType", 'IsWorkDay', "Week", "Year", "Month", "Day", "Number", 'ShiftDef']

    function GridMain_Add_Click() {
        var p = new TestRecord({
            RuleType: null,
            IsWorkDay: null,
            Week: null,
            Year: null,
            Month: null,
            Day: null,
            Number: null,
            ShiftDef: null
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
            dataSend += "{RuleType:'" + m[i].data['RuleType'] + "',"
                        + " IsWorkDay:'" + m[i].data['IsWorkDay'] + "',"
                        + " Week:'" + m[i].data['Week'] + "',"
                        + " Year:'" + m[i].data['Year'] + "',"
                        + " Month:'" + m[i].data['Month'] + "',"
                        + " Day:'" + m[i].data['Day'] + "',"
                        + " Number:'" + m[i].data['Number'] + "',"
                        + " ShiftDef:'" + m[i].data['ShiftDef'] + "'"
                        + " }";
            if (i < len - 1)
                dataSend += ","
        }
        dataSend += "]}";
        //   dataSend = Ext.util.JSON.encode(dataSend);

        var code = formMain.getComponent('Code').getValue();
        var name = formMain.getComponent('Name').getValue();
        var description = formMain.getComponent('Description').getValue();
        var fromDate = formMain.getComponent('FromDate').getValue();
        var toDate = formMain.getComponent('ToDate').getValue();

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
                FromDate: fromDate,
                ToDate: toDate,
                Rules: dataSend
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
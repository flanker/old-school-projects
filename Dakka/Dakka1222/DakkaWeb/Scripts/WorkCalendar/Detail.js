// WorkCalendar/Detail
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />


Ext.onReady(function() {
    var processID = Ext.get('processID').getValue();

    // 保存数据的变量 全聚德
    var processData;

    // 卡片 ***************************************************************

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
                { id: 'formMain_FromDate', fieldLabel: 'FromDate', name: 'FromDate', xtype: 'datefield', format: 'Y-m-d' },
                { id: 'formMain_ToDate', fieldLabel: 'ToDate', name: 'ToDate', xtype: 'datefield', format: 'Y-m-d'}]
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

    //    var ds = new Ext.data.JsonStore({
    //        data: [{ RuleType: null, IsWorkDay: null, Week: null, Year: null, Month: null, Day: null, Number: null, ShiftDef: null}],
    //        fields: ["RuleType", 'IsWorkDay', "Week", "Year", "Month", "Day", "Number", 'ShiftDef']
    //    });

    var ds = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({ url: 'GetRules?ID=' + processID, method: 'GET' }),
        reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root' },
            [{ name: 'RuleType' }, { name: 'IsWorkDay' }, { name: 'Week' }, { name: 'Year' }, { name: 'Month' }, { name: 'Day' }, { name: 'Number' }, { name: 'ShiftDef'}])
    });
    ds.load();

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
            data: [['Week', 'Week'], ['Month', 'Month'], ['Year', 'Year'], ['Date', 'Date']]
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
            data: [['True', 'True'], ['False', 'False']]
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
            data: [['Monday', 'Monday'], ['Tuesday', 'Tuesday'], ['Wednesday', 'Wednesday'], ['Thursday', 'Thursday'], ['Friday', 'Friday'], ['Saturday', 'Saturday'], ['Sunday', 'Sunday']]
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
        { header: "RuleType", width: 70, dataIndex: 'RuleType', sortable: true, editor: RuleTypeComboBox },
        { header: "IsWorkDay", width: 70, dataIndex: 'IsWorkDay', sortable: true, editor: IsWorkDayComboBox },
        { header: "Week", width: 70, dataIndex: 'Week', sortable: true, editor: WeekComboBox },
        { header: "Year", width: 50, dataIndex: 'Year', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Month", width: 50, dataIndex: 'Month', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Day", width: 50, dataIndex: 'Day', sortable: true, editor: new Ext.form.NumberField() },
        { header: "Number", width: 50, dataIndex: 'Number', sortable: true, editor: new Ext.form.NumberField() },
        { header: "ShiftDef", width: 70, dataIndex: 'ShiftDef', sortable: true, editor: new Ext.form.ShiftDefRefField() }
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

        var dataSend = "{data: ["

        for (var i = 0, len = ds.getCount(); i < len; i++) {
            var rec = ds.getAt(i);
            dataSend += "{RuleType:'" + rec.get('RuleType') + "',"
                        + " IsWorkDay:'" + rec.get('IsWorkDay') + "',"
                        + " Week:'" + rec.get('Week') + "',"
                        + " Year:'" + rec.get('Year') + "',"
                        + " Month:'" + rec.get('Month') + "',"
                        + " Day:'" + rec.get('Day') + "',"
                        + " Number:'" + rec.get('Number') + "',"
                        + " ShiftDef:'" + rec.get('ShiftDef') + "'"
                        + " }";

            if (i < len - 1)
                dataSend += ","
        }
        dataSend += "]}";
        //   dataSend = Ext.util.JSON.encode(dataSend);

        var code = formMain.getComponent('formMain_Code').getValue();
        var name = formMain.getComponent('formMain_Name').getValue();
        var description = formMain.getComponent('formMain_Description').getValue();
        var fromDate = formMain.getComponent('formMain_FromDate').getRawValue();
        var toDate = formMain.getComponent('formMain_ToDate').getRawValue();

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
                FromDate: fromDate,
                ToDate: toDate,
                Rules: dataSend
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
            Ext.getCmp('formMain_FromDate').setValue(processData.FromDate);
            Ext.getCmp('formMain_ToDate').setValue(processData.ToDate);
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
// Employee/List
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />


Ext.onReady(function() {

    // 数据和Grid, Form, Window ******************************************** 

    // 创建DataStore
    var ds = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({ url: 'GetSome', method: 'GET' }),
        reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root', id: 'id' },
            [{ name: 'ID' }, { name: 'Code' }, { name: 'Name' }, { name: 'Email' }, { name: 'Dept'}])
    });

    // 创建Grid选择框列
    var sm = new Ext.grid.CheckboxSelectionModel();

    // 创建Grid列
    var cm = new Ext.grid.ColumnModel([
                new Ext.grid.RowNumberer(),
                sm,
                { header: "ID", width: 60, dataIndex: 'ID', sortable: true },
                { header: "Code", width: 120, dataIndex: 'Code', sortable: true },
                { header: "Name", width: 120, dataIndex: 'Name', sortable: true },
                { header: "Email", width: 160, dataIndex: 'Email', sortable: true },
                { header: "Dept", width: 160, dataIndex: 'Dept', sortable: true }
            ]);

    // 创建Grid
    var gridMain = new Ext.grid.GridPanel({
        store: ds,
        cm: cm,
        sm: sm,
        stripeRows: true,
        height: 500,
        renderTo: 'gridAll',
        loadMask: true,

        // 底部Bar: 翻页
        bbar: new Ext.PagingToolbar({
            pageSize: 20,
            store: ds,
            displayInfo: true,
            displayMsg: 'From {0} to {1} , total: {2}',
            emptyMsg: "No record"
        }),

        // 首部Bar: 按钮
        tbar: new Ext.Toolbar({
            items: [{ id: 'ButtonNew', text: 'Add', tooltip: 'Add new employee', iconCls: 'add', handler: ButtonNew_Click },
                    { id: 'ButtonEdit', text: 'Edit', tooltip: 'Edit selected employee', iconCls: 'edit', handler: ButtonEdit_Click },
                    { id: 'ButtonRemove', text: 'Remove', tooltip: 'Remove selected employee', iconCls: 'remove', handler: ButtonRemove_Click },
                    { id: 'ButtonRefresh', text: 'Refresh', tooltip: 'Refresh the datagrid', iconCls: 'refresh', handler: ButtonRefresh_Click}]
        })
    });

    // 创建新增Form
    var formAddNew = new Ext.FormPanel({
        labelAlign: 'top',
        labelWidth: 75,
        url: 'New',
        method: 'post',
        frame: true,
        bodyStyle: 'padding:5px 5px 0',
        width: 350,
        height: 400,
        defaults: { width: 200, autoHeight: true },
        defaultType: 'textfield',
        monitorValid: true,
        buttonAlign: 'right',

        items: [{ fieldLabel: 'Code', name: 'Code', allowBlank: false },
                { fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { fieldLabel: 'Email', name: 'Email', allowBlank: false },
                { fieldLabel: 'Dept', name: 'Dept', allowBlank: true}],

        buttons: [{ text: "OK", handler: formAddNew_OK_Click, formBind: true },
                  { text: "Reset", handler: formAddNew_Reset_Click },
                  { text: 'Close', handler: formAddNew_Close_Click}]
    });

    // 创建新增Window
    var windowAddNew = new Ext.Window({
        el: 'windowNew',
        layout: 'fit',
        resizable: false,
        modal: true,
        // autoHeight: true,
        width: 350,
        height: 400,
        title: 'Add new Employee',
        closeAction: 'hide',
        plain: true,
        items: formAddNew
    }); // new

    // 创建编辑Form
    var formEdit = new Ext.FormPanel({
        labelAlign: 'top',
        labelWidth: 75,
        url: 'Edit',
        method: 'post',
        frame: true,
        bodyStyle: 'padding:5px 5px 0',
        width: 350,
        height: 400,
        defaults: { width: 200, autoHeight: true },
        defaultType: 'textfield',
        monitorValid: true,
        buttonAlign: 'right',

        items: [{ id: 'Edit_Code', fieldLabel: 'Code', name: 'Code', allowBlank: false },
                { id: 'Edit_Name', fieldLabel: 'Name', name: 'Name', allowBlank: false },
                { id: 'Edit_Email', fieldLabel: 'Email', name: 'Email', allowBlank: false },
                { id: 'Edit_Dept', fieldLabel: 'Dept', name: 'Dept', allowBlank: true}],

        buttons: [{ text: "OK", handler: formEdit_OK_Click, formBind: true },
                  { text: 'Close', handler: formEdit_Close_Click}]
    });

    // 创建编辑Window
    var windowEdit = new Ext.Window({
        el: 'windowEdit',
        layout: 'fit',
        resizable: false,
        modal: true,
        // autoHeight: true,
        width: 350,
        height: 400,
        title: 'Edit Employee',
        closeAction: 'hide',
        plain: true,
        items: formEdit
    }); // new

    // gridMain上的Toolbar事件处理 ******************************************** 

    function ButtonNew_Click() {
        // window.location.href = "New"; // 跳转到新的页面

        windowAddNew.show(Ext.get("ButtonNew"));
    }

    function ButtonRefresh_Click() {
        ds.load({
            params: { start: 0, limit: 20 },
            callback: function() {
                Ext.flanker.msg('Refresh', 'Refresh success!');
            }
        });
        gridMain.getSelectionModel().selectFirstRow();

    }

    function ButtonEdit_Click() {
        gridMain.stopEditing();             // 取消编辑状态
        var selectedItems = gridMain.selModel.selections.keys;      //获取选中的行标识对象集合，和读取器中的id属性密切相关
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select one record!');
        }
        else {
            var selectedRow = gridMain.getSelectionModel().getSelected();
            // formEdit.getForm().loadRecord(selectedRow);
            Ext.getCmp('Edit_Code').setValue(selectedRow.get('Code'));
            //            Ext.getCmp('Edit_Code').disabled = true;
            Ext.getCmp('Edit_Name').setValue(selectedRow.get('Name'));
            Ext.getCmp('Edit_Email').setValue(selectedRow.get('Email'));
            Ext.getCmp('Edit_Dept').setValue(selectedRow.get('Dept'));
            windowEdit.show(Ext.get('ButtonEdit'));
        }
        gridMain.startEditing(0, 0);
    }

    function ButtonRemove_Click() {
        gridMain.stopEditing();             // 取消编辑状态
        var selectedItems = gridMain.selModel.selections.keys;      //获取选中的行标识对象集合，和读取器中的id属性密切相关
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select one record!');
        }
        else {
            Ext.MessageBox.confirm('Remove', 'Are you sure?', doRemove);
        }
        gridMain.startEditing(0, 0);
    }

    // 真正的删除
    function doRemove(dialogResult) {
        if (dialogResult == "yes") {
            var selectedItems = gridMain.selModel.selections.keys;

            var selectedRow = gridMain.getSelectionModel().getSelected();

            var removeID = selectedRow.get('ID');

            var markRemoving = new Ext.LoadMask(Ext.getBody(), { msg: "Removing..." });
            markRemoving.show();

            Ext.Ajax.request({
                url: 'Remove',
                method: 'post',
                params: { ID: removeID },
                success: function(response, options) {
                    markRemoving.hide();
                    var result = Ext.util.JSON.decode(response.responseText);
                    // Ext.Msg.alert('Remove', result.msg);
                    Ext.flanker.msg('Remove', result.msg);
                    ds.load({ params: { start: 0, limit: 20} });
                    gridMain.getSelectionModel().selectFirstRow();
                },
                failure: function(response, options) {
                    markRemoving.hide();
                    Ext.Msg.alert('Error', result.msg);
                }
            });

            markRemoving.destroy();
        }
    }

    // formAddNew上的事件处理 **************************************************** 

    function formAddNew_OK_Click() {
        if (formAddNew.getForm().isValid())        //表单数据验证
        {
            formAddNew.getForm().submit({          //提交表单
                waitMsg: 'saving...',
                success: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    // Ext.Msg.alert("Success", jsonobject.msg);
                    Ext.flanker.msg("Success", jsonobject.msg);
                    formAddNew.getForm().reset();
                    windowAddNew.hide();
                    ds.load({ params: { start: 0, limit: 20} });
                    gridMain.getSelectionModel().selectFirstRow();
                },
                failure: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    Ext.Msg.alert("Error", jsonobject.msg);
                    formAddNew.items[0].focus();
                }
            });
        }
    }

    function formAddNew_Reset_Click() {
        formAddNew.getForm().reset();
    }

    function formAddNew_Close_Click() {
        formAddNew.getForm().reset();
        windowAddNew.hide();
    }

    // formEdit上的事件处理 **************************************************** 

    function formEdit_OK_Click() {
        if (formEdit.getForm().isValid())        //表单数据验证
        {
            formEdit.getForm().submit({          //提交表单
                waitMsg: 'updating...',
                success: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    // Ext.Msg.alert("Success", jsonobject.msg);
                    Ext.flanker.msg("Success", jsonobject.msg);
                    formEdit.getForm().reset();
                    windowEdit.hide();
                    ds.load({ params: { start: 0, limit: 20} });
                    gridMain.getSelectionModel().selectFirstRow();
                },
                failure: function(re, v) {
                    var jsonobject = Ext.util.JSON.decode(v.response.responseText);
                    Ext.Msg.alert("Error", jsonobject.msg);
                }
            });
        }
    }

    function formEdit_Close_Click() {
        formEdit.getForm().reset();
        windowEdit.hide();
    }

    // 加载数据并展示 ****************************************************
    ds.load({ params: { start: 0, limit: 20} });
    gridMain.getSelectionModel().selectFirstRow();


    // 公共方法 **********************************************************

    function GridLoad() {

    }
});
// Shift/List
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    // 数据和Grid, Form, Window ******************************************** 

    // 创建DataStore
    var ds = new Ext.data.Store({
        proxy: new Ext.data.HttpProxy({ url: 'GetSome', method: 'GET' }),
        reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root', id: 'id' },
            [{ name: 'ID' }, { name: 'Code' }, { name: 'Name' }, { name: 'Description' }, { name: 'ShiftType'}])
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
                { header: "Description", width: 160, dataIndex: 'Description', sortable: true },
                { header: "ShiftType", width: 160, dataIndex: 'ShiftType', sortable: true }
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
            items: [{ id: 'ButtonNew', text: 'Add', tooltip: 'Add new shift', iconCls: 'add', handler: ButtonNew_Click },
                    { id: 'ButtonDetail', text: 'Detail', tooltip: 'View the shift detail', iconCls: 'edit', handler: ButtonDetail_Click },
                    { id: 'ButtonRemove', text: 'Remove', tooltip: 'Remove selected shift', iconCls: 'remove', handler: ButtonRemove_Click },
                    { id: 'ButtonRefresh', text: 'Refresh', tooltip: 'Refresh the datagrid', iconCls: 'refresh', handler: ButtonRefresh_Click}]
        })
    });

    // gridMain上的Toolbar事件处理 ******************************************** 

    function ButtonNew_Click() {
        window.location.href = "New"; // 跳转到新的页面
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

    function ButtonDetail_Click() {
        var selectedItems = gridMain.selModel.selections.keys;      //获取选中的行标识对象集合，和读取器中的id属性密切相关
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select one record!');
        }
        else {
            var selectedRow = gridMain.getSelectionModel().getSelected();
            window.location.href = "Detail?ID=" + selectedRow.get('ID'); // 跳转到新的页面
        }
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

    // 加载数据并展示 ****************************************************
    ds.load({ params: { start: 0, limit: 20} });
    gridMain.getSelectionModel().selectFirstRow();


    // 公共方法 **********************************************************

    function GridLoad() {

    }
});
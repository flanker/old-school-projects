// Shared/Base
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.BLANK_IMAGE_URL = '../../Content/Images/s.gif';

Ext.onReady(function() {
    Ext.QuickTips.init();
    Ext.form.Field.prototype.msgTarget = 'side';
});

/*******************************************************************************************************/
// 
Ext.flanker = function() {
    var msgCt;
    function createBox(t, s) {
        return ['<div class="msg">',
                '<div class="x-box-tl"><div class="x-box-tr"><div class="x-box-tc"></div></div></div>',
                '<div class="x-box-ml"><div class="x-box-mr"><div class="x-box-mc"><h3>', t, '</h3>', s, '</div></div></div>',
                '<div class="x-box-bl"><div class="x-box-br"><div class="x-box-bc"></div></div></div>',
                '</div>'].join('');
    }
    return {
        msg: function(title, content) {
            if (!msgCt) {
                msgCt = Ext.DomHelper.insertFirst(document.body, { id: 'msg-div' }, true);
            }
            msgCt.alignTo(document, 't-t');
            var m = Ext.DomHelper.append(msgCt, { html: createBox(title, content) }, true);
            m.slideIn('t').pause(1).ghost("t", { remove: true });
        },
        showResult: function(responseText) {
            var result = Ext.util.JSON.decode(responseText)
            if (result.success == true) {
                Ext.flanker.msg('Success', result.msg);
            }
            else {
                Ext.Msg.alert('Error', result.msg);
            }
        }
    };
} ();

/*******************************************************************************************************/

Ext.form.ExComboBox = Ext.extend(Ext.form.ComboBox, {
    fieldLabel: null,
    name: null,
    allowBlank: true,
    mode: 'local',
    readOnly: true,
    triggerAction: 'all',
    emptyText: 'Select...',
    valueField: 'value',
    displayField: 'text',
    initComponent: function() {

        var datas = [];
        for (var i = 0; i < this.ExData.length; i++) {
            datas[i] = [this.ExData[i], this.ExData[i]];
        }
        Ext.apply(this, {
            store: new Ext.data.SimpleStore({
                fields: ['value', 'text'],
                data: datas
            })
        });
        Ext.form.ComboBox.superclass.initComponent.call(this);
    }
});

/*******************************************************************************************************/
// List页面
Ext.grid.ListGridPanel = Ext.extend(Ext.grid.GridPanel, {
    gridItems: null,
    height: 500,
    renderTo: 'gridAll',
    loadMask: true,
    stripeRows: true,
    viewConfig: {
        forceFit: true
    },
    initComponent: function() {
        var m_Sm = new Ext.grid.CheckboxSelectionModel();
        var arrayForStore = [];
        var arrayForCm = [];
        arrayForCm.push(m_Sm);
        for (var i = 0; i < this.gridItems.length; i++) {
            arrayForStore.push({ name: this.gridItems[i].dataIndex });
            arrayForCm.push(this.gridItems[i]);
        }
        var m_Cm = new Ext.grid.ColumnModel(arrayForCm);
        Ext.apply(this, {
            sm: m_Sm
        });
        Ext.apply(this, {
            cm: m_Cm
        });
        Ext.apply(this, {
            ds: new Ext.data.Store({
                proxy: new Ext.data.HttpProxy({ url: 'GetSome', method: 'GET' }),
                reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root', id: 'id' }, arrayForStore)
            })
        });
        this.ds.load({ params: { start: 0, limit: 20} });
        Ext.apply(this, {
            tbar: [{ id: 'ButtonNew', text: 'New', tooltip: 'Add new shift', iconCls: 'new', handler: this.ButtonNew_Click, scope: this },
                   '-',
                   { id: 'ButtonDetail', text: 'Detail', tooltip: 'View the shift detail', iconCls: 'edit', handler: this.ButtonDetail_Click, scope: this },
                   '-',
                   { id: 'ButtonDelete', text: 'Delete', tooltip: 'Delete selected shift', iconCls: 'delete', handler: this.ButtonDelete_Click, scope: this },
                   '-',
                   { id: 'ButtonRefresh', text: 'Refresh', tooltip: 'Refresh the datagrid', iconCls: 'refresh', handler: this.ButtonRefresh_Click, scope: this}]
        });
        Ext.apply(this, {
            bbar: new Ext.PagingToolbar({
                pageSize: 20,
                store: this.ds,
                displayInfo: true,
                displayMsg: 'From {0} to {1} , total: {2}',
                emptyMsg: "No record"
            })
        });
        Ext.grid.ListGridPanel.superclass.initComponent.call(this);

    },
    ButtonNew_Click: function() {
        window.location.href = "Detail?ID=0";
    },
    ButtonRefresh_Click: function() {
        this.store.load({ params: { start: 0, limit: 20 }, callback: function() { Ext.flanker.msg('Refresh', 'Refresh success!'); } });
    },
    ButtonDetail_Click: function() {
        var selectedItems = this.selModel.selections.keys;
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select one record!');
        }
        else {
            var selectedRow = this.getSelectionModel().getSelected();
            window.location.href = "Detail?ID=" + selectedRow.get('ID');
        }
    },
    ButtonDelete_Click: function() {
        var selectedItems = this.selModel.selections.keys;
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select one record!');
        }
        else {
            Ext.MessageBox.confirm('Remove', 'Are you sure?', this.DoRemove, this);
        }
    },
    DoRemove: function(dialogResult, t) {
        if (dialogResult == "yes") {
            var selectedItems = this.selModel.selections.keys;
            var selectedRow = this.getSelectionModel().getSelected();
            var removeID = selectedRow.get('ID');
            var markRemoving = new Ext.LoadMask(Ext.getBody(), { msg: "Removing..." });
            markRemoving.show();
            Ext.Ajax.request({
                url: 'Remove',
                method: 'post',
                params: { ID: removeID },
                scope: this,
                success: function(response, options) {
                    markRemoving.hide();
                    Ext.flanker.showResult(response.responseText);
                    this.store.load({ params: { start: 0, limit: 20} });
                    this.getSelectionModel().selectFirstRow();
                },
                failure: function(response, options) {
                    markRemoving.hide();
                    Ext.Msg.alert('Error', result.msg);
                }
            });
            markRemoving.destroy();
        }
    }
});

/*******************************************************************************************************/

Ext.form.ExFormPanel = Ext.extend(Ext.form.FormPanel, {
    labelAlign: 'right',
    labelWidth: 75,
    frame: true,
    bodyStyle: 'padding:5px 5px 0',
    width: 'auto',
    height: 'auto',
    defaults: { width: 200, height: 20 },
    defaultType: 'textfield',
    monitorValid: true,
    buttonAlign: 'left'
});

/*******************************************************************************************************/

Ext.NewPanel = Ext.extend(Ext.Panel, {
    formItems: null,
    gridItems: null,
    renderTo: 'divMain',
    loadMask: true,
    stripeRows: true,
    viewConfig: {
        forceFit: true
    },
    initComponent: function() {
        this.form = new Ext.form.ExFormPanel({ items: this.formItems });
        if (this.gridItems != null) {
            var m_Sm = new Ext.grid.CheckboxSelectionModel();
            var arrayForRecord = [];
            var arrayForStore = [];
            var arrayForCm = [];
            arrayForCm.push(m_Sm);
            for (var i = 0; i < this.gridItems.length; i++) {
                arrayForRecord.push({ name: this.gridItems[i].dataIndex, type: 'string' });
                arrayForStore.push(this.gridItems[i].dataIndex);
                arrayForCm.push({ header: this.gridItems[i].header,
                    width: this.gridItems[i].width,
                    dataIndex: this.gridItems[i].dataIndex,
                    sortable: true,
                    editor: this.gridItems[i].editor
                });
            }
            this.RowRecord = Ext.data.Record.create(arrayForRecord);
            this.ds = new Ext.data.JsonStore({
                data: [new this.RowRecord()],
                fields: arrayForStore
            });
            var m_Cm = new Ext.grid.ColumnModel(arrayForCm);
            this.grid = new Ext.grid.EditorGridPanel({
                ds: this.ds,
                cm: m_Cm,
                sm: m_Sm,
                stripeRows: true,
                height: 350,
                clicksToEdit: 1,
                tbar: [{ id: 'ButtonAdd', text: 'Add', tooltip: 'Add new record', iconCls: 'add', handler: this.Grid_Add_Click, scope: this },
                       { id: 'ButtonRemove', text: 'Remove', tooltip: 'Remove selected record', iconCls: 'remove', handler: this.Grid_Remove_Click, scope: this}]
            });
        }
        if (this.gridItems != null) {
            Ext.apply(this, {
                items: [this.form, this.grid]
            });
        }
        else {
            Ext.apply(this, {
                items: [this.form]
            });
        }
        Ext.apply(this, {
            tbar: new Ext.Toolbar({
                items: [{ id: 'ButtonSave', text: 'Save', tooltip: 'Save this data', iconCls: 'save', handler: this.Panel_Save_Click, scope: this },
                    '-',
                    { id: 'ButtonClean', text: 'Clean', tooltip: 'Clean all forms', iconCls: 'clean', handler: this.Panel_Clean_Click, scope: this },
                    '-',
                    { id: 'ButtonReturn', text: 'Return', tooltip: 'Return to the list', iconCls: 'return', handler: this.Panel_Return_Click, scope: this}]
            })
        });
        Ext.NewPanel.superclass.initComponent.call(this);

    },
    Grid_Add_Click: function() {
        var arrayForP = [];
        for (var i = 0; i < this.gridItems.length; i++) {
            arrayForP.push([this.gridItems[i].dataIndex, null]);
        }
        var p = new this.RowRecord(arrayForP);

        this.grid.stopEditing();
        this.ds.add(p);
        this.grid.startEditing(0, 0);
    },
    Grid_Remove_Click: function() {
        var selectedRow = this.grid.getSelectionModel().getSelected();
        if (selectedRow) {
            this.ds.remove(selectedRow);
        }
    },
    Panel_Save_Click: function() {
        // var m = this.ds.getModifiedRecords();
        // if (m.length == 0) {
        //     return false;
        // }
        var param = {};
        for (var i = 0; i < this.formItems.length; i++) {
            if (this.form.getComponent(this.formItems[i].name).xtype == 'datefield') {
                param[this.formItems[i].name] = this.form.getComponent(this.formItems[i].name).getRawValue();
            }
            else {
                param[this.formItems[i].name] = this.form.getComponent(this.formItems[i].name).getValue();
            }
        }
        if (this.gridItems != null) {
            var dataSend = '{data: ['
            for (var i = 0, len = this.ds.length; i < len; i++) {
                dataSend += '{';
                for (var j = 0; j < this.gridItems.length; j++) {
                    dataSend += " " + this.gridItems[j].dataIndex + ":'" + m[i].data[this.gridItems[j].dataIndex] + "',";
                }
                dataSend += '}';
                if (i < len - 1)
                    dataSend += ","
            }
            dataSend += "]}";
            param['Lines'] = dataSend;
        }

        var mark = new Ext.LoadMask(Ext.getBody(), { msg: "Saving..." });
        mark.show();

        Ext.Ajax.request({
            url: 'AddNew',
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
            params: param
        });

        mark.destroy();
    },

    Panel_Clean_Click: function() {

    },

    Panel_Return_Click: function() {
        window.location.href = "List";
    }
});

/*******************************************************************************************************/

Ext.DetailPanel = Ext.extend(Ext.Panel, {
    formItems: null,
    gridItems: null,
    processID: null,
    renderTo: 'divMain',
    loadMask: true,
    stripeRows: true,
    viewConfig: {
        forceFit: true
    },
    initComponent: function() {
        this.form = new Ext.form.ExFormPanel({ items: this.formItems });
        if (this.gridItems != null) {
            var m_Sm = new Ext.grid.CheckboxSelectionModel();
            var arrayForRecord = [];
            var arrayForStore = [];
            var arrayForCm = [];
            arrayForCm.push(m_Sm);
            for (var i = 0; i < this.gridItems.length; i++) {
                arrayForRecord.push({ name: this.gridItems[i].dataIndex, type: 'string' });
                arrayForStore.push({ name: this.gridItems[i].dataIndex });
                arrayForCm.push({ header: this.gridItems[i].header,
                    width: this.gridItems[i].width,
                    dataIndex: this.gridItems[i].dataIndex,
                    sortable: true,
                    editor: this.gridItems[i].editor
                });
            }
            this.RowRecord = Ext.data.Record.create(arrayForRecord);
            this.ds = new Ext.data.Store({
                proxy: new Ext.data.HttpProxy({ url: 'GetLines?ID=' + this.processID, method: 'GET' }),
                reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root' }, arrayForStore)
            })
            var m_Cm = new Ext.grid.ColumnModel(arrayForCm);
            this.grid = new Ext.grid.EditorGridPanel({
                ds: this.ds,
                cm: m_Cm,
                sm: m_Sm,
                stripeRows: true,
                height: 350,
                clicksToEdit: 1,
                tbar: [{ id: 'ButtonAdd', text: 'Add', tooltip: 'Add new record', iconCls: 'add', handler: this.Grid_Add_Click, scope: this },
               { id: 'ButtonRemove', text: 'Remove', tooltip: 'Remove selected record', iconCls: 'remove', handler: this.Grid_Remove_Click, scope: this}]
            });
        }
        if (this.gridItems != null) {
            Ext.apply(this, {
                items: [this.form, this.grid]
            });
        }
        else {
            Ext.apply(this, {
                items: [this.form]
            });
        }
        Ext.apply(this, {
            tbar: new Ext.Toolbar({
                items: [{ id: 'ButtonNew', text: 'New', tooltip: 'Add new shift', iconCls: 'new', handler: this.Panel_New_Click, scope: this },
                    '-',
                    { id: 'ButtonSave', text: 'Save', tooltip: 'Save this data', iconCls: 'save', handler: this.Panel_Save_Click, scope: this },
                    '-',
                    { id: 'ButtonDelete', text: 'Delete', tooltip: 'Delete this record', iconCls: 'delete', handler: this.Panel_Delete_Click, scope: this },
                    '-',
                    { id: 'ButtonList', text: 'List', tooltip: 'Return to the list', iconCls: 'list', handler: this.Panel_List_Click, scope: this },
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
        if (this.processID != '0') {
            this.LoadData();
        }
        Ext.DetailPanel.superclass.initComponent.call(this);
    },
    Grid_Add_Click: function() {
        var arrayForP = [];
        for (var i = 0; i < this.gridItems.length; i++) {
            arrayForP.push([this.gridItems[i].dataIndex, null]);
        }
        var p = new this.RowRecord(arrayForP);

        this.grid.stopEditing();
        this.ds.add(p);
        this.grid.startEditing(0, 0);
    },
    Grid_Remove_Click: function() {
        var selectedRow = this.grid.getSelectionModel().getSelected();
        if (selectedRow) {
            this.ds.remove(selectedRow);
        }
    },
    Panel_New_Click: function() {
        window.location.href = "Detail?ID=0";
    },
    Panel_Save_Click: function() {
        var param = {};
        param['ID'] = this.processID;
        for (var i = 0; i < this.formItems.length; i++) {
            param[this.formItems[i].name] = this.form.getComponent(this.formItems[i].name).getValue();
        }
        if (this.gridItems != null) {

            var dataSend = '{data: ['
            for (var i = 0, len = this.ds.getCount(); i < len; i++) {
                dataSend += '{';
                for (var j = 0; j < this.gridItems.length; j++) {
                    dataSend += " " + this.gridItems[j].dataIndex + ":'" + this.ds.getAt(i).data[this.gridItems[j].dataIndex] + "',";
                }
                dataSend += '}';
                if (i < len - 1)
                    dataSend += ","
            }
            dataSend += "]}";
            param['Lines'] = dataSend;
        }

        var mark = new Ext.LoadMask(Ext.getBody(), { msg: "Updating..." });
        mark.show();

        var realUrl = (this.processID == '0' ? 'AddNew' : 'Update');

        Ext.Ajax.request({
            url: realUrl,
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
            params: param
        });

        mark.destroy();
    },
    Panel_Delete_Click: function() {

    },
    Panel_List_Click: function() {
        window.location.href = "List";
    },
    LoadData: function() {
        Ext.Ajax.request({
            url: 'GetByID',
            method: 'GET',
            scope: this,
            success: function(result, request) {
                processData = Ext.util.JSON.decode(result.responseText);
                Ext.flanker.msg("Success", 'load data success');

                for (var i = 0; i < this.formItems.length; i++) {
                    this.form.getComponent(this.formItems[i].name).setValue(processData[this.formItems[i].name]);
                }
            },
            failure: function(result, request) {
                Ext.Msg.alert("Error", result.responseText);
            },
            params: {
                ID: this.processID
            }
        });
        if (this.gridItems != null) {
            this.ds.load();
        }
    }
});
// Shared/EmployeeRefField
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.form.EmployeeRefField = Ext.extend(Ext.form.TriggerField, {

    triggerClass: 'x-form-ref-trigger',

    initComponent: function() {
        Ext.form.ComboBox.superclass.initComponent.call(this);
        this.ds = new Ext.data.Store({
            proxy: new Ext.data.HttpProxy({ url: '../Employee/GetSome', method: 'GET' }),
            reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root', id: 'id' },
                [{ name: 'ID' }, { name: 'Code' }, { name: 'Name' }, { name: 'Email' }, { name: 'Dept'}])
        });
        this.ButtonOK = new Ext.Button({ text: 'OK', tooltip: 'OK', iconCls: 'add' });
        this.sm = new Ext.grid.CheckboxSelectionModel();
        this.cm = new Ext.grid.ColumnModel([
                this.sm,
                { header: "ID", width: 60, dataIndex: 'ID', sortable: true, hidden: true },
                { header: "Code", width: 80, dataIndex: 'Code', sortable: true },
                { header: "Name", width: 80, dataIndex: 'Name', sortable: true },
                { header: "Email", width: 160, dataIndex: 'Email', sortable: true },
                { header: "Dept", width: 100, dataIndex: 'Dept', sortable: true }
            ]);
        this.gridMain = new Ext.grid.GridPanel({
            store: this.ds,
            cm: this.cm,
            sm: this.sm,
            stripeRows: true,
            height: 300,
            width: 500,
            loadMask: true,
            bbar: new Ext.PagingToolbar({
                pageSize: 20,
                store: this.ds,
                displayInfo: true,
                displayMsg: 'From {0} to {1} , total: {2}',
                emptyMsg: "No record"
            }),

            tbar: new Ext.Toolbar({ items: [this.ButtonOK] })
        });
        this.windowRef = new Ext.Window({
            layout: 'fit',
            modal: true,
            height: 300,
            width: 500,
            title: 'Select',
            closeAction: 'hide',
            plain: true,
            items: this.gridMain
        });
        this.ButtonOK.on('click', this.ButtonOK_Click, this, { preventDefault: true });
    },

    ButtonOK_Click: function() {
        var selectedItems = this.gridMain.selModel.selections.keys;
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select on record!');
        }
        else {
            var selectedRow = this.gridMain.getSelectionModel().getSelected();
            this.windowRef.hide();
            this.setValue(selectedRow.get('Code'));
        }
    },
    onTriggerClick: function() {
        this.ds.load({ params: { start: 0, limit: 20} });
        //this.gridMain.getSelectionModel().selectFirstRow();
        this.windowRef.show();
    }
});
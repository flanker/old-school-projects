Ext.form.ShiftDefRefField = Ext.extend(Ext.form.TriggerField, {

    triggerClass: 'x-form-ref-trigger',
    defaultAutoCreate: { tag: "input", type: "text", size: "10", autocomplete: "off" },    // *

    initComponent: function() {
        Ext.form.ComboBox.superclass.initComponent.call(this);
//    },

//    onRender: function(ct, position) {
//        Ext.form.ShiftDefRefField.superclass.onRender.call(this, ct, position);
//        this.on('focus', this.initList, this, { single: true });
//    },

//    initList: function() {
        this.ds = new Ext.data.Store({
            proxy: new Ext.data.HttpProxy({ url: 'GetSomeShiftDefRef', method: 'GET' }),
            reader: new Ext.data.JsonReader({ totalProperty: 'totalProperty', root: 'root', id: 'id' },
                [{ name: 'ID' }, { name: 'Code' }, { name: 'Name' }, { name: 'Description' }, { name: 'ShiftType'}])
        });
        this.ButtonOK = new Ext.Button({ id: 'RefButtonOK', text: 'OK', tooltip: 'OK', iconCls: 'add' });
        this.sm = new Ext.grid.CheckboxSelectionModel();
        this.cm = new Ext.grid.ColumnModel([
            this.sm,
            { header: 'Code', width: 80, dataIndex: 'Code', sortable: true },
            { header: 'Name', width: 100, dataIndex: 'Name', sortable: true },
            { header: 'Description', width: 140, dataIndex: 'Description', sortable: true },
            { header: 'ShiftType', width: 80, dataIndex: 'ShiftType', sortable: true}]);
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

            tbar: new Ext.Toolbar({
                items: [this.ButtonOK]
            })
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
        //this.ButtonOK.on('click', this.ButtonOK_Click, this, { preventDefault: true });
        this.ButtonOK.on('click', this.ButtonOK_Click, this);
        this.windowRef.on('hide', this.windowRef_Hide, this);

    },

    windowRef_Hide: function() {
        Ext.get(Ext.isIE ? document.body : document).on("mousedown", this.mimicBlur, this, { delay: 10 });
    },

    ButtonOK_Click: function() {
        var selectedItems = this.gridMain.selModel.selections.keys;
        if (selectedItems.length == 0) {
            Ext.MessageBox.alert('Error', 'Please select on record!');
        }
        else {

            var selectedRow = this.gridMain.getSelectionModel().getSelected();
            var text = selectedRow.get('Code');

            this.setValue(text);
            this.windowRef.hide();
        }
    },
    onTriggerClick: function() {
        this.ds.load({ params: { start: 0, limit: 20} });
        this.windowRef.show();
        Ext.get(Ext.isIE ? document.body : document).un("mousedown", this.mimicBlur, this);
    },
    setValue: function(text) {
        Ext.form.ShiftDefRefField.superclass.setValue.call(this, text);
    }
});
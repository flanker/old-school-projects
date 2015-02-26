// WorkCalendar/List
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    var gridItems = [{ header: "ID", width: 60, dataIndex: 'ID', sortable: true, hidden: true },
        { header: "Code", width: 80, dataIndex: 'Code', sortable: true },
        { header: "Name", width: 120, dataIndex: 'Name', sortable: true },
        { header: "Description", width: 180, dataIndex: 'Description', sortable: true },
        { header: "FromDate", width: 100, dataIndex: 'FromDate', sortable: true },
        { header: "ToDate", width: 100, dataIndex: 'ToDate', sortable: true }];

    var gridMain = new Ext.grid.ListGridPanel({
        gridItems: gridItems
    });

});
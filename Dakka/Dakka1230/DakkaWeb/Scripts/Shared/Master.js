// Shared/Master
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.onReady(function() {

    var viewport = new Ext.Viewport({
        layout: 'border',
        items: [
                new Ext.BoxComponent({ // raw
                    region: 'north',
                    el: 'north',
                    height: 32
                }), {
                    region: 'south',
                    contentEl: 'south',
                    split: true,
                    height: 32
                }, {
                    region: 'east',
                    title: 'Misc',
                    collapsible: true,
                    split: true,
                    width: 225,
                    minSize: 175,
                    maxSize: 400,
                    layout: 'fit',
                    margins: '0 5 0 0',
                    items:
                        new Ext.TabPanel({
                            border: false,
                            activeTab: 0,
                            tabPosition: 'bottom',
                            items: [{
                                el: 'east1',
                                title: 'Help',
                                autoScroll: true
                            },
                            new Ext.grid.PropertyGrid({
                                title: 'Property',
                                closable: true,
                                source: {
                                    "(name)": "Properties",
                                    "grouping": false,
                                    "autoFitColumns": true,
                                    "productionQuality": false,
                                    "created": new Date(Date.parse('10/15/2006')),
                                    "tested": false,
                                    "version": .01,
                                    "borderWidth": 1
                                }
                            })]
                        })
                }, {
                    region: 'west',
                    id: 'west-panel',
                    title: 'Menu',
                    split: true,
                    width: 200,
                    minSize: 175,
                    maxSize: 400,
                    collapsible: true,
                    margins: '0 0 0 5',
                    layout: 'accordion',
                    layoutConfig: {
                        animate: true
                    },
                    items: [{
                        contentEl: 'navigation',
                        title: 'Navigation',
                        border: false,
                        iconCls: 'nav'
                    }, {
                        contentEl: 'settings',
                        title: 'Settings',
                        border: false,
                        iconCls: 'settings'}]
                    },
                new Ext.TabPanel({
                    region: 'center',
                    deferredRender: false,
                    activeTab: 0,
                    items: [{ contentEl: 'center2', title: 'Main Panel', autoScroll: true}]
                })
             ]
    });
});
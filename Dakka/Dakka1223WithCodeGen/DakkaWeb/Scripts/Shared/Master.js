// Shared/Master
/// <reference path="../../Extjs/adapter/ext/ext-base.js" />
/// <reference path="../../Extjs/ext-all-debug.js" />

Ext.BLANK_IMAGE_URL = '../../Content/Images/s.gif';

Ext.onReady(function() {

    Ext.QuickTips.init();

    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';

    // NOTE: This is an example showing simple state management. During development,
    // it is generally best to disable state management as dynamically-generated ids
    // can change across page loads, leading to unpredictable results.  The developer
    // should ensure that stable state ids are set for stateful components in real apps.
    //Ext.state.Manager.setProvider(new Ext.state.CookieProvider());

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

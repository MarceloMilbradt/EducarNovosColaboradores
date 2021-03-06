/**
 * @class Ext.ux.Portlet
 * @extends Ext.Panel
 * A {@link Ext.Panel Panel} class that is managed by {@link Ext.ux.PortalPanel}.
 */
Ext.define('Ext.ux.Portlet', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.portlet',
    layout: 'fit',
    anchor: '100%',
    margin: '5 0 0 0',
    border: true,
    frame: false,
    closable: true,
    collapsible: true,
    animCollapse: true,
    draggable: true,
    //cls: 'x-portlet',
    // Override Panel's default doClose to provide a custom fade out effect
    // when a portlet is removed from the portal
    doClose: function () {
        this.el.animate({
            opacity: 0,
            callback: function () {
                //this.fireEvent('close', this);
                this[this.closeAction]();
            },
            scope: this
        });
    }
});
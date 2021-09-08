/*

This file is part of Ext JS 4

Copyright (c) 2011 Sencha Inc

Contact:  http://www.sencha.com/contact

GNU General Public License Usage
This file may be used under the terms of the GNU General Public License version 3.0 as published by the Free Software Foundation and appearing in the file LICENSE included in the packaging of this file.  Please review the following information to ensure the GNU General Public License version 3.0 requirements will be met: http://www.gnu.org/copyleft/gpl.html.

If you are unsure which license is appropriate for your use, please contact the sales department at http://www.sencha.com/contact.

*/
/**
 * @class Ext.chooser.IconBrowser
 * @extends Ext.view.View
 * @author Ed Spencer
 * 
 * This is a really basic subclass of Ext.view.View. All we're really doing here is providing the template that dataview
 * should use (the tpl property below), and a Store to get the data from. In this case we're loading data from a JSON
 * file over AJAX.
 */
Ext.define('Ext.chooser.IconBrowser', {
    extend: 'Ext.view.View',
    alias: 'widget.iconbrowser',

    uses: 'Ext.data.Store',

    singleSelect: true,
    overItemCls: 'x-view-over',
    itemSelector: 'div.thumb-wrap',
    tpl: [
        // '<div class="details">',
            '<tpl for=".">',
                '<div class="thumb-wrap" align="center">',
                    '<div class="thumb">',
                    (!Ext.isIE6 ? '<img src="https://docs.sencha.com/extjs/4.0.7/extjs-build/examples/view/chooser/icons/{cpn_imagem}" />' :
                    '<div style="width:74px;height:74px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\'https://docs.sencha.com/extjs/4.0.7/extjs-build/examples/view/chooser/icons/{cpn_imagem}\')"></div>'),
                    '</div>',
                    '<span>{cpn_titulo}</span>',
                '</div>',
            '</tpl>'
        // '</div>'
    ],

    initComponent: function () {
        this.store = Ext.create('Ext.data.Store', {
            autoLoad: true,
            fields: ['cpn_titulo', 'cpn_descricao', 'cpn_imagem', 'type'],
            proxy: {
                type: 'ajax',
                url: 'Abs_componentepainel/ListarPorTipoPessoa',
                reader: {
                    type: 'json',
                    root: 'componentespainel'
                }
            }
        });

        this.callParent(arguments);
        this.store.sort();
    }
});

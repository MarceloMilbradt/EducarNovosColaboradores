Ext.create('Ext.form.Panel', {
    title: '',
    layout: 'anchor',
    margin: '5 5 5 5',
    defaults: {
        anchor: '100%'
    },
    items: [
        Ext.create('Ext.container.Container', {
            layout: {
                type: 'hbox'
            },
            margin: '5 5 5 5',
            renderTo: Ext.getBody(),
            items: [
                Ext.create('Ext.grid.Panel', {
                    title: 'Simpsons',                    
                    store: storeGridMtr,
                    columns: [
                        { header: 'Name', dataIndex: 'name' },
                        { header: 'Email', dataIndex: 'email', flex: 1 },
                        { header: 'Phone', dataIndex: 'phone' }
                    ],
                    tbar: {
                        items: [

                        ]
                    },
                    renderTo: Ext.getBody()
                })
            ]
        }),        
    ],
    renderTo: Ext.getBody()
});
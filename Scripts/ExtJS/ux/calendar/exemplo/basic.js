/*!
 * Extensible 1.0.2
 * Copyright(c) 2010-2012 Extensible, LLC
 * licensing@ext.ensible.com
 * http://ext.ensible.com
 */
Ext.onReady(function(){
    
    var eventStore = new Ext.ensible.sample.MemoryEventStore({
        // defined in data/events.js
        data: Ext.ensible.sample.EventData
    });
    
    //
    // example 1: simplest possible stand-alone configuration
    //
    new Ext.ensible.cal.CalendarPanel({
        eventStore: eventStore,
        renderTo: 'simple',
        title: 'Basic Calendar',
        width: 700,
        height: 500
    });
    
    //
    // example 2: shows off some common Ext.Panel configs as well as a 
    // few extra CalendarPanel-specific configs + a calendar store
    //
   
});
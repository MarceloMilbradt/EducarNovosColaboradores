/*
 * examples from https://tpodolak.com/blog/2012/07/19/extjs-4-1-1-multiselectable-datepicker/
 * and https://fiddle.sencha.com/#fiddle/84j&view/editor
 * 
 * */

Ext.define('HighlightableDatePicker', {
	extend: 'Ext.picker.Date',
	alias: "widget.highlightdate",
	selectedDates: {},
	dates: [],
	onSelect: null,
	clsHigligthClass: 'x-datepicker-selected',
	initComponent: function () {
		var me = this;
		me.callParent(arguments);
		me.on('select', me.handleSelectionChanged, me);
		me.on('afterrender', me.higlighDates, me);
	},
	showPrevMonth: function (e) {
		var me = this;
		var c = this.update(Ext.Date.add(this.activeDate, Ext.Date.MONTH, -1));
		me.higlighDates();
		return c;
	},
	showNextMonth: function (e) {
		var me = this;
		var c = this.update(Ext.Date.add(this.activeDate, Ext.Date.MONTH, 1));
		me.higlighDates();
		return c;
	},
	higlighDates: function () {
		var me = this;
		if (!me.cells)
			return;
		me.cells.each(function (item) {
			var date = new Date(item.dom.firstChild.dateValue).toDateString();
			if (me.selectedDates[date]) {
				if (item.getAttribute('class').indexOf(me.clsHigligthClass) === -1) {
					item.addCls(me.clsHigligthClass);
				}
			} else {
				item.removeCls(me.clsHigligthClass);
			}
		})
	},

	setDates: function (dates) {
		if (typeof dates === 'object' && dates !== null && !Array.isArray(dates))
			dates = [dates];

		if (Array.isArray(dates)) {
			var me = this;

			for (var i = 0; i < dates.length; i++) {
				var date = dates[i];

				if (!me.selectedDates[date.toDateString()]) {
					me.selectedDates[date.toDateString()] = date;
					me.dates.push(date);
				}
			}

			me.higlighDates();
		}
	},
	getDates: function () {
		var me = this;
		return me.dates;
	},
	removeDates: function (dates) {
		if (typeof dates === 'object' && dates !== null && !Array.isArray(dates))
			dates = [dates];

		if (Array.isArray(dates)) {

			var me = this;

			for (var i = 0; i < dates.length; i++) {
				var date = dates[i];

				if (me.selectedDates[date.toDateString()]) {
					delete me.selectedDates[date.toDateString()];

					var index = me.dates.findIndex(item => {
						return item.toDateString() == date.toDateString();
					});

					if (index !== -1) {
						me.dates.splice(index, 1);
					}
				}
			}

			me.higlighDates();
		}
	},
	clear: function () {
		var me = this;

		for (var i = 0; i < me.dates.length; i++) {
			var date = me.dates[i];
			delete me.selectedDates[date.toDateString()];
		}

		me.dates.splice(0, me.dates.length);

		me.higlighDates();
	},
	handleSelectionChanged: function (cmp, date) {
		var me = this;
		/* COMENTADO DEVIDO A IMPLEMENTAÇÃO ABAIXO, PARA CONTROLAR EM ARRAY DAS DATAS
		 * if (me.selectedDates[date.toDateString()])
			delete me.selectedDates[date.toDateString()]
		else
			me.selectedDates[date.toDateString()] = date;
		me.higlighDates();*/

		if (me.selectedDates[date.toDateString()]) {
			delete me.selectedDates[date.toDateString()];
			
			var index = me.dates.findIndex(item => {
				return item.toDateString() == date.toDateString();
			});

			if (index !== -1) {
				me.dates.splice(index, 1);
			}
		} else {
			me.selectedDates[date.toDateString()] = date;
			me.dates.push(date);
		}

		me.higlighDates();

		if (Ext.isFunction(me.onSelect)) {
			me.onSelect(cmp, date);
		}
	}
});
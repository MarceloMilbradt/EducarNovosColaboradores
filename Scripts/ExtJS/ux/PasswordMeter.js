Ext.define('Ext.ux.PasswordMeter',
    {
        extend: 'Ext.form.field.Text',
        alias: 'widget.passwordMeter',
        inputType: 'password',

        reset: function () {
            this.callParent();
            this.updateMeter(this);
        },

        //private
        onRender: function (container, position) {
            var me = this;
            me.callParent(arguments);

            this.objMeter = me.el.createChild({
                tag: "div",
                'class': "strengthMeter"
            });
            me.objMeter.setWidth(me.el.getWidth(true));
            me.scoreBar = me.objMeter.createChild({
                tag: "div",
                'class': "scoreBar"
            });

            me.scoreBar.setWidth(me.objMeter.getWidth(true));

            if (Ext.isIE6) { // Fix style for IE6
                this.objMeter.setStyle('margin-left', '3px');
            }
            this.objMeter.setVisible(false);
        },

        // private
        initEvents: function () {
            var me = this, el = me.inputEl;
            me.callParent();
            me.mon(el, {
                scope: me,
                keyup: me.updateMeter
            });
        },
        /**
        * Sets the width of the meter, based on the score
        *
        * @param {Object} e
        * Private function
        */
        updateMeter: function () {
            var score, p, maxWidth, nScore, scoreWidth;
            score = 0;
            p = this.getValue();
            maxWidth = this.objMeter.getWidth() - 2;
            nScore = this.calcStrength(p);

            scoreWidth = maxWidth - (maxWidth / 100) * nScore;

            this.scoreBar.setWidth(scoreWidth, true);
            //            alert(nScore);
            if (nScore == 0) {
                this.objMeter.setVisible(false);
            } else {
                this.objMeter.setVisible(true);
            }
        },

        /**
        * Calculates the strength of a password
        *
        * @param {Object} p
        *   The password that needs to be calculated
        * @return {int} intScore The strength score of the password
        */
        barraVisivel: function (visivel) {
            this.objMeter.setVisible(visivel);

        },
        getPontos: function () {
            p = this.getValue();
            return this.calcStrength(p);
        },

        calcStrength: function (p) {
            var intScore = 0;

            // PASSWORD LENGTH
            intScore += p.length;

            if (p.length > 0 && p.length <= 4) { // length 4 or
                // less
                intScore += 0;
            } else if (p.length >= 5 && p.length <= 7) {
                // length between 5 and 7
                intScore += 10;
            } else if (p.length >= 8 && p.length <= 15) {
                // length between 8 and 15
                intScore += 15;
            } else if (p.length >= 16) { // length 16 or more
                intScore += 20;
            }

            // LETTERS (Not exactly implemented as dictacted above
            // because of my limited understanding of Regex)
            if (p.match(/[a-z]/)) {
                // [verified] at least one lower case letter
                intScore += 1;
            } else {
                intScore += -6;
            }
            if (p.match(/[A-Z]/)) { // [verified] at least one upper
                // case letter
                intScore += 8;
            }
            // NUMBERS
            if (p.match(/\d/)) { // [verified] at least one
                // number
                intScore += 3;
            }
            if (p.match(new RegExp(".*\\d.*\\d.*\\d"))) {
                // [verified] at least three numbers
                intScore += 5;
            }

            // SPECIAL CHAR
            if (p.match(new RegExp("[!,@,#,$,%,^,&,*,?,_,~]"))) {
                // [verified] at least one special character
                intScore += 15;
            }
            // [verified] at least two special characters
            if (p.match(new RegExp(
          ".*[!,@,#,$,%,^,&,*,?,_,~].*[!,@,#,$,%,^,&,*,?,_,~]"
        ))) {
                intScore += 15;
            }

            // COMBOS
            if (p.match(new RegExp("(?=.*[a-z])(?=.*[A-Z])"))) {
                // [verified] both upper and lower case
                intScore += 2;
            }
            if (p.match(new RegExp(
        "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])"))) {
                // [verified] both letters and numbers
                intScore += 2;
            } else {
                intScore += -3;
            }
            // [verified] letters, numbers, and special characters
            if (p.match(new RegExp(
          "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!,@,#,$,%,^,&,*,?,_,~])"
          ))) {
                intScore += 2;
            }

            //            if ((!(p.match(/[a-z]/)) || !(p.match(/[A-Z]/))) && p.match(new RegExp("*\\d"))) {
            //                intScore += -6;
            //            }            

            if (!p.match(/[a-zA-Z]$/)) {
                intScore += -20;
            }

            var nRound = Math.round(intScore * 2);

            if (nRound <= 0) {
                if (p.length > 0) {
                    nRound = 1;
                } else {
                    nRound = 0;
                }
            }

            if (nRound > 100) {
                nRound = 100;
            }

            return nRound;
        }
    })
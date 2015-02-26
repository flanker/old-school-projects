/// <reference path="jquery-1.3.2-vsdoc.js" />

$.NiceJForms = {
    options: {
        imagesPath: "/content/images/niceform/"
    },

    build: function() {
        //var el = $('form.niceform');
        //$('input[type=submit]', el).add($('input[type=button]'), el).each(function(i) {
        $('input[type=submit]').add($('input[type=button]')).each(function(i) {
            $(this).addClass("buttonSubmit");
            var buttonLeft = document.createElement('img');
            $(buttonLeft).attr({ src: $.NiceJForms.options.imagesPath + "button_left.gif" }).addClass("buttonImg");

            $(this).before(buttonLeft);

            var buttonRight = document.createElement('img');
            $(buttonRight).attr({ src: $.NiceJForms.options.imagesPath + "button_right.gif" }).addClass("buttonImg");

            if ($(this).next()) {
                $(this).after(buttonRight)
            }
            else {
                $(this).parent().append(buttonRight)
            }
            ;

            $(this).hover(
                    function() {
                        $(this).attr("class", $(this).attr("class") + "Hovered");
                        $(this).prev().attr("src", $.NiceJForms.options.imagesPath + "button_left_xon.gif");
                        $(this).next().attr("src", $.NiceJForms.options.imagesPath + "button_right_xon.gif")
                    },
                    function() {
                        $(this).attr("class", $(this).attr("class").replace(/Hovered/g, ""));
                        $(this).prev().attr("src", $.NiceJForms.options.imagesPath + "button_left.gif");
                        $(this).next().attr("src", $.NiceJForms.options.imagesPath + "button_right.gif")
                    }
                    );
        });

        if (!$.browser.safari) {
            $('input[type=text]').add($('input[type=password]')).add($('textarea')).focus(function() {
                $(this).addClass("inputFocus");
            }).blur(function() {
                $(this).removeClass("inputFocus");
            });
        }
    }
}
(function($) {
    var selector = {
        form: "form.ajax",
        dialog: "div.modal-dialog",
        errorMessage: "div.message",
        error: "div.error-message",
        content : "#content"
    };
    
    var onSuccess = function (responseText, statusText, xhr, form) {

        debugger;

        renderResponse(responseText, form);
        $.App.init();
    };

    var onError = function(xhr) {
        renderResponse(xhr.responseText);
    };

    var showErrorMessage = function (message, container) {

        var closeButton = $("<button></button>")
            .text("×")
            .addClass("close")
            .attr({
                "type": "button",
                "data-dismiss": "alert",
                "aria-hidden": "true"
            });

        $("<div></div>")
            .text(message)
            .addClass("alert")
            .addClass("alert-danger")
            .addClass("fade in")
            .prepend(closeButton)
            .prependTo($(container));

    };

    var showSuccessMessage = function (message) {

        var $message = $("<div></div>")
			.addClass("message")
			.text(message);

        $(document.body).append($message);
        animateMessage();
    };

    var animateMessage = function () {

        var message = $(selector.message);

        if (message.length == 0) {
            return;
        }

        $(selector.message + ".animating").remove();

        $(document.body).append(message.remove());

        var content = $(selector.content);
        var offset = content.offset();

        var top = offset.top;
        var left = offset.left;

        var scrollTop = $(document).scrollTop();

        message.offset({
            "left": left,
            "top": scrollTop > 0 ? scrollTop : top
        });

        message.addClass("animating").slideDown();

        $(document).one("scroll", function () {
            message.css("top", "0");
        });

        window.setTimeout(function () {
            message.slideUp("normal", function () {
                message.remove();
            });
        }, 3000);

    };

    var renderResponse = function(response, form) {

        alert(response);

        var $response = $(response);
        var target = form.closest(selector.dialog);

        if (target.length > 0) {
            
            target.html($response);
        }
    };

    var init = function() {
        var options = {
            success: onSuccess,
            error: onError
        };

        $(selector.form + (":not(.setup)"))
            .ajaxForm(options)
            .addClass("setup");

        animateMessage();
        initErrorMessage();
    };

    var initErrorMessage = function () {

        var closeButton = $("<button></button>")
            .text("×")
            .addClass("close")
            .attr({
                "type": "button",
                "data-dismiss": "alert",
                "aria-hidden": "true"
            });

        $(selector.errorMessage + ":not(.setup)")
            .removeClass(selector.errorMessage)
            .addClass("alert")
            .addClass("alert-danger")
            .addClass("fade in")
            .prepend(closeButton)
            .addClass("setup");

    };


    $.App.Forms = {
        init: init,
        DisplaySuccessMessage: showSuccessMessage,
        DisplayErrorMessage: showErrorMessage
    };

})(jQuery);
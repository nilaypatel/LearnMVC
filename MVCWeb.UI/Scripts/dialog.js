(function ($) {

    var selector = {
        dialog: ".dialog",
        close: ".closeDialog"
    };

    var attribute = {
        url: "data-url"
    };
    
    var currentDialog = null;
    var openDialog = function (url) {

        if (currentDialog != null) {
            currentDialog.remove();
        }

        var modalDialogHtml = $("<div></div>")
            .addClass("modal-dialog");

        var callback = function (response) {
            modalDialogHtml.html(response);
        };

        $.App.get(url, { callback: callback });

        var modalDialog = $("<div></div>")
            .addClass("modal fade")
            .attr({
                "role": "dialog",
                "aria-labelledby": "customDialog",
                "aria-hidden": "true"
            })
            .append(modalDialogHtml);
        
        $(document.body).prepend(modalDialog);

        var options = {
            keyboard: false
        };
        currentDialog = modalDialog
            .modal(options)
            .modal("show");
    };

    var closeDialog = function () {
        
        if (currentDialog == null) {
            return;
        }

        currentDialog.modal("hide");
    };

    var init = function () {

        $(selector.dialog + ":not(.setup)").click(function () {

            var activator = $(this);
            var url = activator.attr(attribute.url);

            openDialog(url);
        })
        .addClass("setup");

        $(selector.close + ":not(.setup)").click(function() {
                closeDialog();
            })
        .addClass("setup");
    };

    $.App.Dialogs = {
        init: init,
        close : closeDialog
    };

})(jQuery);
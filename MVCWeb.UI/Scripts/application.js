(function ($) {

    var init = function () {
        $.App.Dialogs.init();
        $.App.Forms.init();
    };

    var getRequest = function (url, options) {
        ajaxRequest("GET", url, options);
    };

    var postRequest = function (url, options) {
        ajaxRequest("POST", url, options);
    };

    var ajaxRequest = function (requestType, url, options) {

        options = $.extend({
            data: null,
            callback: $.noop()
        }, options);

        var successfulCallback = function (response, status, jqXHR) {
            if ($.isFunction(options.callback)) {
                options.callback(response);
            }

            init();
        };

        var errorCallback = function (jqXHR, textStatus, errorThrown) {
            if ($.isFunction(options.callback)) {
                options.callback(jqXHR.responseText);
            }
        };

        var settings = {
            type: requestType,
            url: url,
            data: options.data,
            success: successfulCallback,
            error: errorCallback,
            cache: false
        };

        $.ajax(settings);
    };

    var trimQueryString = function (url) {

        var index, trimedUrl = url;

        if ((index = url.indexOf('?')) > -1) {
            trimedUrl = url.substring(0, index);
        }
       
        return trimedUrl;
    };

    $.App = {
        init : init,
        get: getRequest,
        post: postRequest,
        trimQueryString: trimQueryString
    };

})(jQuery);

(function ($) {
    $(document).ready(function () {
        var messageBox = $('#message-box').messageBox();
        $("#success").click(function(){
            messageBox.success('Success message.');
        });

        $("#error").click(function(){
            messageBox.error('Error message.');
        });
    });
})(jQuery);

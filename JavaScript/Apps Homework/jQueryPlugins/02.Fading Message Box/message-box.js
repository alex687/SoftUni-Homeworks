var MessageBox = (function () {
    var SHOWING_REMOVING_INTERVAL = 1000,
        TIME_LIVE = 3000;

    function MessageBox($this) {
        this.$this = $this;
    }

    function box(className, parrent) {
        var $box = $('<div class="messageBox ' + className + '">')
            .fadeIn(SHOWING_REMOVING_INTERVAL)
            .appendTo(parrent);

        setTimeout(
            function () {
                $box.fadeOut(SHOWING_REMOVING_INTERVAL);
            },
            TIME_LIVE
        );
        return $box;
    }

    MessageBox.prototype.success = function (message) {
        return box('success', this.$this).text(message);
    };

    MessageBox.prototype.error = function (message) {
        return box('error', this.$this).text(message);
    };

    MessageBox.prototype.getjQueryObject = function getjQueryObject() {
        return this.$this
    };

    return MessageBox;
})();

$.fn.messageBox = function () {
    return new MessageBox(this);
};

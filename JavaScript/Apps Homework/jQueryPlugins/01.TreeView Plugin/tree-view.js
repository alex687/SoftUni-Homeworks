(function ($) {
    $.fn.treeView = function () {
        function toggleOnClick(event) {
            event.stopPropagation();

            $(this).children("ul").each(function () {
                var $this = $(this);
                if ($this.is(":visible")) {
                    $this.hide();
                }
                else {
                    $this.show();
                }
            });
        }

        this.children().click(toggleOnClick);

        this.children().children().each(function () {
            var $this = $(this);
            if ($this.is("ul")) {
                $this.hide();
            }

            if ($this.is("li")) {
                $this.click(toggleOnClick);
            }

            $this.children().each(arguments.callee);
        });
    };
})(jQuery);
$.fn.sideshow = function () {
    _this = this;

    var leftButton = this.children(".sideshow-control.left");
    leftButton.click(function () {
        var activeElement = _this.children(".item.active");

        if (activeElement.prev().length > 0) {
            activeElement.prev().attr('class', 'item active').fadeIn(500);
            activeElement.attr('class', 'item').hide();
        }
        else {
            activeElement.removeClass('active', true).hide();
            _this.children(".item").last().attr('class', 'item active').fadeIn(500);
        }
    });


    var rightButton = this.children(".sideshow-control.right");
    rightButton.click(function () {
        var activeElement = _this.children(".item.active");
        if (activeElement.next(".item").length > 0) {
            activeElement.next().attr('class', 'item active').fadeIn(500);
            activeElement.attr('class', 'item').hide();
        }
        else {
            activeElement.removeClass('active', true).hide();
            _this.children(".item").first().attr('class', 'item active').fadeIn(500);
        }
    });

    this.children(".item.active").first().css("display", "block");
};

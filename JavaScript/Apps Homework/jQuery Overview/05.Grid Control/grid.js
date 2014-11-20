var Grid = (function () {
    function Grid($this) {
        this.$this = $this;
    };

    Grid.prototype.addHeader = function addHeader(headers) {
        if (headers.length < 1) {
            throw Error("Invalid headers");
        }

        var thead = $("<thead>");
        headers.forEach(function (item) {
            var th = $("<th>").text(item);
            thead.append(th);
        });

        this.$this.children("thead").remove();

        this.$this.append(thead);
    };

    Grid.prototype.addRow = function addRow(data) {
        var tr = $("<tr>");

        for (var key in data) {
            var newTd = $("<td>").text(data[key]);
            tr.append(newTd);
        }

        this.$this.append(tr);
    };

    Grid.prototype.getjQueryObject = function getjQueryObject() {
        return this.$this
    };

    return Grid;
})();

$.fn.grid = function () {

    return new Grid(this);
};

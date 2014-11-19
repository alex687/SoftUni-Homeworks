(function ($) {
    String.prototype.capitalize = function () {
        return this.charAt(0).toUpperCase() + this.slice(1);
    };

    function createTable(jsonData, appendTo) {
        var table = $("<table>");

        function createHead() {
            var thead = $("<thead>");

            Object.keys(jsonData[0]).forEach(function (item) {
                var th = $("<th>").text(item.capitalize());
                thead.append(th);
            });

            return thead;
        }

        function insertData() {
            var tbody = $("<tbody>");

            for (var i = 0, length = jsonData.length; i < length; i++) {
                var tr = createRowWithData(i);

                tbody.append(tr);
            }

            return tbody;
        }

        function createRowWithData(jsonDataIndex) {
            var tr = $("<tr>");
            var jsonDataRow = jsonData[jsonDataIndex];
            for (var key in jsonDataRow) {
                console.log(jsonDataRow[key]);
                var newTd = $("<td>").text(jsonDataRow[key]);
                tr.append(newTd);
            }
            return tr;
        }

        table.append(createHead());
        table.append(insertData());
        $(appendTo).append(table);

    }

    $(document).ready(function () {
        var jsonData = JSON.parse('[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},' +
        '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
        '{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]');

        createTable(jsonData, document.body);
    });
})(jQuery);
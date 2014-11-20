(function ($) {




    $(document).ready(function () {
        var grid =  $("#myGrid").grid();
        grid.addHeader([1,23]);

        var grid2 =  $("#myGrid").grid();
        grid.addHeader(['First Name', 'Last Name', 'Age']);
       	grid.addRow(['Bay', 'Ivan', 50]);
       	grid.addRow(['Kaka', 'Penka', 26]);

        console.log(grid.addHeader === grid2.addHeader);

        $("#myGrid").addHeader();
    });
})(jQuery);

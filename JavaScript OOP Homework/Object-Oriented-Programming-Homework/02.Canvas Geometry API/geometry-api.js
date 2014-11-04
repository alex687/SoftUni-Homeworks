(function () {
    var shapes = [];

    var shapeToDraw = document.getElementById("shape");
    shapeToDraw.onchange = function shapeOnChange() {
        var aditionalInfoChilds = document.getElementById("additionalInfo").children;
        for (var i = 0; i < aditionalInfoChilds.length; i++) {
            aditionalInfoChilds[i].style.display = "none";
        }

        var selectedValue = this.value;
        switch (selectedValue) {
            case '1':
                document.getElementById('secondPoint').style.display = 'block';
                document.getElementById('thirdPoint').style.display = 'block';
                break;
            case '2':
                document.getElementById('rectangle').style.display = 'block';
                break;
            case '3':
                document.getElementById('circle').style.display = 'block';
                break;
            case '4':
                document.getElementById('secondPoint').style.display = 'block';
                break;
        }
    };

    var addButton = document.getElementById("addButton");
    var shapesSelect = document.getElementById("shapes");
    addButton.onclick = function addButtonOnClick() {
        var shape = makeShape(shapeToDraw.value);
        shapes.push(shape);
        shape.draw();

        var option = document.createElement("option");
        option.text = shape.toString();
        shapesSelect.add(option);
    };

    var removeButton = document.getElementById("remove");
    removeButton.onclick = function removeButtonClick(){
        var options = shapesSelect && shapesSelect.options;

        for (var i=0, iLen=options.length; i<iLen; i++) {
            var opt = options[i];

            if (opt.selected) {
                opt.remove();
            }
        }
    };

    function removeShape(index){
        shapes[index].remove();
    }

    function makeShape(shapeToMake){
        switch (shapeToMake) {
            case '0':
                return ShapeFactory.Point();
            case '1':
                return ShapeFactory.Triangle();
            case '2':
                return ShapeFactory.Rectangle();
            case '3':
                return ShapeFactory.Circle();
            case '4':
                return ShapeFactory.Segment();
        }
    }
})();
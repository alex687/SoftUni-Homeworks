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
    removeButton.onclick = function removeButtonClick() {
        var options = shapesSelect && shapesSelect.options;

        for (var i = 0, iLen = options.length; i < iLen; i++) {
            var opt = options[i];

            if (opt.selected) {
                opt.remove();
                shapes.splice(i, 1);
                refreshCanvas();
            }
        }
    };

    var upButton = document.getElementById("up");
    upButton.onclick = function upButtonClick() {
        var options = shapesSelect && shapesSelect.options;
        var index = shapesSelect.selectedIndex;
        if (index - 1 >= 0) {
            swapOptions(options, index, index - 1);
            swapCanvasElements(shapes, index, index - 1);
            shapesSelect.selectedIndex = index - 1;
        }
    };

    var downButton = document.getElementById("down");
    downButton.onclick = function downButtonClick() {
        var options = shapesSelect && shapesSelect.options;
        var index = shapesSelect.selectedIndex;
        if (index + 1 < options.length) {
            swapOptions(options, index, index + 1);
            swapCanvasElements(shapes, index, index + 1);
            shapesSelect.selectedIndex = index + 1;
        }
    };

    function swapOptions(options, firstOptionIndex, secondOptionIndex) {
        var OptText = options[firstOptionIndex].text;
        options[firstOptionIndex].text = options[secondOptionIndex].text;
        options[secondOptionIndex].text = OptText;
    }

    function swapCanvasElements(elements, firstElementIndex, secondElementIndex) {
        var shape = shapes[firstElementIndex];
        shapes[firstElementIndex] = shapes[secondElementIndex];
        shapes[secondElementIndex] = shape;
        refreshCanvas();
    }

    function refreshCanvas() {
        var canvas = document.getElementById("shapesContainer");
        canvas.width = canvas.width;
        for (var index in shapes) {
            if (shapes[index] instanceof Shapes.Shape) {
                shapes[index].draw();
            }
        }
    }

    function makeShape(shapeToMake) {
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
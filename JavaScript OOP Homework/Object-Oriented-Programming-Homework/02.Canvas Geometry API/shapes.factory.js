var ShapeFactory = (function () {
    function getPoint() {
        var x, y, color, point;

        x = document.getElementById('x').value;
        y = document.getElementById('y').value;
        color = document.getElementById('color').value;
        point = new Shapes.Point(x, y, color);

        return point;
    }

    function getSegment() {
        var x, y,
            x2, y2,
            color, segment;

        x = document.getElementById('x').value;
        y = document.getElementById('y').value;
        x2 = document.getElementById('x2').value;
        y2 = document.getElementById('y2').value;
        color = document.getElementById('color').value;
        segment = new Shapes.Segment(x, y, color, x2, y2);

        return segment;
    }

    function getTriangle() {
        var x, y,
            x2, y2,
            x3, y3,
            color, triangle;

        x = document.getElementById('x').value;
        y = document.getElementById('y').value;
        x2 = document.getElementById('x2').value;
        y2 = document.getElementById('y2').value;
        x3 = document.getElementById('x3').value;
        y3 = document.getElementById('y3').value;
        color = document.getElementById('color').value;
        triangle = new Shapes.Triangle(x, y, color, x2, y2, x3, y3);

        return triangle;
    }

    function getRectangle() {
        var x, y,
            width, height,
            color,
            rectangle;

        x = document.getElementById('x').value;
        y = document.getElementById('y').value;
        width = document.getElementById('width').value;
        height = document.getElementById('height').value;
        color = document.getElementById('color').value;
        rectangle = new Shapes.Rectangle(x, y, color, width, height);

        return rectangle;
    }

    function getCircle() {
        var x, y,
            radius,
            color,
            circle;

        x = document.getElementById('x').value;
        y = document.getElementById('y').value;
        radius = document.getElementById('radius').value;
        color = document.getElementById('color').value;
        circle = new Shapes.Circle(x, y, color, radius);

        return circle;
    }

    return {
        Point: getPoint,
        Triangle: getTriangle,
        Rectangle: getRectangle,
        Circle: getCircle,
        Segment: getSegment
    };
}());
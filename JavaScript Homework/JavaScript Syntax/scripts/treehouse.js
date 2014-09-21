function treeHouseCompare(a  , b){
    var triangleArea = (a * (a * 2 / 3)) / 2;
    var squareArea = a*a;
    var houseArea = squareArea + triangleArea;

    var circleRadius = b * 2 / 3;
    var rectangleArea =  b * (b / 3);
    var treeArea = rectangleArea + (Math.PI * Math.pow(circleRadius, 2));

    if(treeArea > houseArea){
        return "tree/" + treeArea.toFixed(2);
    }

    return "house/" + houseArea.toFixed(2);
}

console.log(treeHouseCompare(3,2));
console.log(treeHouseCompare(3,3));
console.log(treeHouseCompare(4,5));
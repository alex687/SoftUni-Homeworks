function calcCylinderVol(radius, height){
    return (Math.PI * radius *radius * height).toFixed(3);
}

console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));
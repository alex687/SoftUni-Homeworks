function createArray() {
    var array = new Array(20);
    var arr = new Array(20);
    for (var i = 0; i < arr.length; i++) {
        arr[i] = i * 5;
    }

   return arr.join(", ");
}

console.log(createArray());
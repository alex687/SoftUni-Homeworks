function printNumbers(n){
    var numbers = [];
    for ( var i = 1; i<=n; i++){
        if(i % 4 != 0 && i % 5 !=0 ){
            numbers.push(i);
        }
    }
    if(numbers.length == 0){
        return "no";
    }

    return numbers.join(',');
}

console.log(printNumbers(20));
console.log(printNumbers(-5));
console.log(printNumbers(13));
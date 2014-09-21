function findLargestBySumOfDigits() {

    function isInt(value) {
        return !isNaN(value) && parseInt(Number(value)) == value;
    }

    if (arguments.length == 0) {
        return undefined;
    }

    var maxSumDigitsNumber = 0,
        maxSumNumber = 0;
    for( var i =0 ; i< arguments.length; i++){
        if (isInt(arguments[i])) {
            var number = Math.abs(arguments[i]),
             sum = 0 ;
            while(number > 0){
                sum += number % 10;
                number = Math.floor(number / 10);
            }

            if(sum > maxSumDigitsNumber){
                maxSumDigitsNumber = sum;
                maxSumNumber = arguments[i];
            }
        }
        else{
            return undefined;
        }
    }

    return maxSumNumber;
}

console.log(findLargestBySumOfDigits(5, 10, 15, 111));
console.log(findLargestBySumOfDigits(33, 44, -99, 0, 20));
console.log(findLargestBySumOfDigits('hello'));
console.log(findLargestBySumOfDigits(5, 3.3));
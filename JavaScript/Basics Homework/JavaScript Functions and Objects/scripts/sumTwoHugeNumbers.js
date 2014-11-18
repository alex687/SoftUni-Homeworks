function sumTwoHugeNumbers(firstNumber, secondNumber) {
    var addition = 0;
    var sum = '';
    var length = Math.max(firstNumber.length, secondNumber.length);

    for (var i = firstNumber.length - 1, j = secondNumber.length - 1; i >= 0 && j >= 0; i--, j--) {
        var subSum = parseInt(firstNumber[i]) + parseInt(secondNumber[j]) + addition;
        addition =0;
        if (subSum > 9) {
            addition = 1;
            subSum = subSum % 10;
        }
        sum += subSum;
    }

    if(firstNumber.length > secondNumber.length){
       for(i = i ; i >=0; i--){
            var subSum = parseInt(firstNumber[i]) + addition;
           addition = 0;
            if (subSum > 9) {
                addition = 1;
                subSum = subSum % 10;
            }

           sum += subSum;
        }
    }

    if(firstNumber.length < secondNumber.length){
        for(i = j ; i >=0; i--){
            var subSum = parseInt(secondNumber[i]) + addition;
            addition = 0;
            if (subSum > 9) {
                addition = 1;
                subSum = subSum % 10;
            }

            sum += subSum;
        }
    }

    if (addition > 0) {
        sum += addition;
    }
    return (sum).split("").reverse().join("");
}

console.log(sumTwoHugeNumbers('123456789','123456789'));
console.log(sumTwoHugeNumbers('887987345974539', '4582796427862587'));
console.log(sumTwoHugeNumbers('347135713985789531798031509832579382573195807',
    '817651358763158761358796358971685973163314321'
));
//887987345974539
//4582796427862587
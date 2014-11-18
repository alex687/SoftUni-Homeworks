function divisionBy3(number){
    var digitsSum = 0;
    while(number >= 1){
        digitsSum += number %10;

        number = Math.floor(number / 10);

    }
    if(digitsSum % 3 === 0){
        return true;
    }
    return false;
}

var digits = [12, 188, 591];
for(var i=0; i< digits.length; i++){
    if(divisionBy3(digits[i])){
        console.log("the number is divided by 3 without remainder");
    }
    else {
        console.log("the number is not divided by 3 without remainder")
    }
}

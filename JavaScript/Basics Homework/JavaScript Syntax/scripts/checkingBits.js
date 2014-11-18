function bitChecker(number){
    return ((number >> 3) & 1) == 1;
}

console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));
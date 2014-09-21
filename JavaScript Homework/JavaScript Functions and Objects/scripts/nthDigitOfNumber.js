function findNthDigit(arr) {
    var number = Math.abs(arr[1]).toString();
    number = number.replace(".", '');

    if (number.length < arr[0]) {
        return "The number doesn't have " + arr[0] + " digits";
    }

    return number[Math.abs(arr[0] - number.length)];
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));
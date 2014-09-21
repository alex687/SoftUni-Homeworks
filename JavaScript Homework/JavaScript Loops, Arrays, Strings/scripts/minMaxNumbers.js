function findMinAndMax(numbers) {
    var min = numbers[0] , max = numbers[1];
    for (var key in numbers) {
        if (min > numbers[key]) {
            min = numbers[key];
        }
        if (max < numbers[key]) {
            max = numbers[key];
        }
    }
    return {min: min, max: max};
}

var result = findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);

console.log("Min -> "+result.min+" \nMax -> "+result.max);
console.log();

result = findMinAndMax([2, 2, 2, 2, 2]);
console.log("Min -> "+result.min+" \nMax -> "+result.max);
console.log();

result = findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);
console.log("Min -> "+result.min+" \nMax -> "+result.max);
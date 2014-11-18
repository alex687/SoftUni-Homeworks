function sortArray(toSort) {

    for (var i = 0; i < toSort.length; i++) {
        var min = toSort[i];
        var index = i;
        for (var j = i; j < toSort.length; j++) {
            if (toSort[j] < min) {
                min = toSort[j];
                index = j;
            }
        }

        toSort[index] = toSort[i];
        toSort[i] = min;
    }
    return toSort;
}

console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));
function findMostFreqNum (numbers){
    var  numberAppearance = {},
        maxApperance = 1;
        maxApperanceNumber = numbers[0];
    for(var key in numbers){
        if(typeof(numberAppearance[numbers[key]]) === 'undefined') {
            numberAppearance[numbers[key]] = 1;
        }
        else{
            numberAppearance[numbers[key]]++;
            if(numberAppearance[numbers[key]] > maxApperance){
                maxApperance = numberAppearance[numbers[key]];
                maxApperanceNumber = numbers[key];
            }
        }

    }

    return maxApperanceNumber + " ("+maxApperance+" times)";
}

console.log(findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));
console.log(findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]));
console.log(findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]));
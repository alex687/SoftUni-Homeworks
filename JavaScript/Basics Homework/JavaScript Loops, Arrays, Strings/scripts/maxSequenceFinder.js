function findMaxSequence(sequence) {
    var maxSequence = [], currentSequence = [];
    for (var i = 0; i < sequence.length; i++) {
        if (currentSequence[currentSequence.length-1] < sequence[i] || currentSequence.length == 0) {
            currentSequence.push(sequence[i]);
        }
        else {
            if (maxSequence.length < currentSequence.length || maxSequence.length == currentSequence.length) {
                maxSequence = currentSequence;
            }
            currentSequence = [sequence[i]];

        }
    }
    if (maxSequence.length < currentSequence.length || maxSequence.length == currentSequence.length) {
        maxSequence = currentSequence;
    }
    if(maxSequence.length == 1 ){
        return "no";
    }
    return maxSequence;
}

console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));
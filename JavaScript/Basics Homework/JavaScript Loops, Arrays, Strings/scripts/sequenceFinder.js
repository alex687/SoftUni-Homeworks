function findMaxSequence(sequence) {
    var maxSequence = [], currentSequence = [];
    for (var i = 0; i < sequence.length; i++) {
        if (currentSequence[0] === sequence[i] || currentSequence.length == 0) {
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
    return maxSequence;
}

console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));
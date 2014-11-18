function findPalindromes (text){
    var words = text.toLowerCase().split(/\W/g), palindromes = [];
    for(var key in words){
        var word = words[key], isPalindrome = true;
        for(var i = 0; i<word.length / 2; i++){
            if(word[i] != word[(word.length-i -1)]){
                isPalindrome = false;
                break;
            }
        }
        if(isPalindrome && word.length > 0){
            palindromes.push(word);
        }
    }

    return palindromes.join(', ');
}

console.log(findPalindromes("'There is a man, his name was Bob.'"));
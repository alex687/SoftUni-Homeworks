function reverseWordsInString(str){
    var words = str.split(" ");
    for(var key in words){
        words[key] = words[key].split("").reverse().join("");
    }

    return words.join(" ");
}

console.log(reverseWordsInString("Hello, how are you."));
console.log(reverseWordsInString("Life is pretty good isn’t it?"));
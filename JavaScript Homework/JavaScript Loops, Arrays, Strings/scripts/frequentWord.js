function findMostFreqWord (text){
    var words = text.toLowerCase().split(/[^A-Za-z]/).filter(function(v){return v!==''}),
     wordAppearance = {},
     maxApperance = 0;
    for(var key in words){
        if(typeof(wordAppearance[words[key]]) === 'undefined') {
            wordAppearance[words[key]] = 1;
        }
        else{
            wordAppearance[words[key]]++;
            if(wordAppearance[words[key]] > maxApperance){
                maxApperance = wordAppearance[words[key]];
            }
        }

    }

    var mostFreqWords = "";
    for(var key in wordAppearance) {
        if(wordAppearance[key] === maxApperance){
            mostFreqWords +=(key+" -> "+maxApperance+" times \n");
        }
    }

    return mostFreqWords;
}

console.log(findMostFreqWord("'in the middle 5 of the night'"));
console.log(findMostFreqWord("'Welcome to SoftUni. Welcome to Java. Welcome everyone.'"));
console.log(findMostFreqWord("'Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'"));
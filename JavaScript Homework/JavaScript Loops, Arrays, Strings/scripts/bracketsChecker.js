function checkBrackets(expression) {
    var bracket = 0;
    for (var i = 0; i < expression.length; i++) {

        if (expression[i] == '(') {
            bracket++;
        }
        else if (expression[i] == ')') {
            bracket--;
        }
        if (bracket < 0) {
            break;
        }
    }
    if (bracket == 0) {
        return "correct";
    }
    else {
       return "incorrect";
    }
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));
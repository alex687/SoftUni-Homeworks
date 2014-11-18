function calcExpression (expression){
    return eval(expression.replace(/[^-()\d/*+.]/g, ''));
}

document.getElementById('eval').onclick = function (){
    document.getElementById('result').innerHTML =
        calcExpression(document.getElementById('expression').value);
}
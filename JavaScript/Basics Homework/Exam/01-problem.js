function Solve(input){
    var numbers = [];
    for(var i=0; i<input.length; i++){
        numbers[i] = parseFloat(parseFloat(input[i]).toFixed(2));
    }
       // console.log(numbers);
    var output = "<table>\n" +
        "<tr><th>Price</th><th>Trend</th></tr>\n";

    var before = numbers[0];
    for(var i=0; i<numbers.length; i++){

        output+="<tr><td>"+numbers[i].toFixed(2)+"</td><td>";
        if(before == numbers[i]){
            output+="<img src=\"fixed.png\"/></td></td>";
        }
        if(before > numbers[i]){
            output+="<img src=\"down.png\"/></td></td>";
        }

        if(before < numbers[i]){
            output+="<img src=\"up.png\"/></td></td>";
        }
        output+="\n";
        before = numbers[i];

    }
    return output+"</table>\n";
}

console.log(Solve(["50","60"]));
console.log(Solve(["1000000.01","1000000", "999999.7", "333", "99"]));
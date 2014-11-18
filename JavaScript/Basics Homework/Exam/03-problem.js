function Solve(input) {
    var data = [];

    function Data(name, first, second, thirth) {
        this.name = name;
        this.first = first;
        this.second = second;
        this.thirth = thirth;
        return this;
    }

    function getName() {
        //   while()
    }

    for (var i = 2; i < input.length - 1; i++) {

        var row = input[i].split(/(<|>)+/);
        var name = "", nums = [];
        for (var j = 0; j < row.length; j++) {
            if (row[j] !== "<" && row[j] !== ">" && row[j] !== "/td" && row[j] !== "/tr" && row[j] !== "td" && row[j] !== "tr") {
                if (isNaN(row[j]) && row[j] !== "-") {
                    name = row[j];
                }
                if (!isNaN(row[j]) || row[j] === "-") {
                    nums.push(row[j]);
                }
            }
        }

        data.push(new Data(name, nums[1], nums[2], nums[3]));

    }

    function calc (datarow){

        var first = datarow.first;
        var second = datarow.second;
        var thirth = datarow.thirth;

        if (datarow.first == "-")
            first = 0

        if (datarow.second == "-")
            second =0;

        if (datarow.thirth == "-")
            thirth = 0

        var max = Number(first) + Number(second) + Number(thirth);
   //     console.log(first +"-"+ second + "-"+ thirth);
        return max;
    }

    var t = 0;
    var noData = true;
    var max = 0;
    do {
        if (!isNaN(data[t].first) || !isNaN(data[t].thirth) || !isNaN(data[t].second)) {
            noData = false;
            max = calc(data[t]);
            var maxData = data[t];
        }
        t++;
    } while (noData && t < data.length)

    if (noData == true) {
        return "no data";
    }

   // console.log(max);

    for (var k = 1; k < data.length; k++) {

        if (max < calc(data[k])) {
            max = calc(data[k]);
            maxData = data[k];
        }
    }

    if(maxData.first == "-" && maxData.second == "-"){
        return  max +" = "+ maxData.thirth;
    }
    if(maxData.second == "-" && maxData.thirth == "-"){
        return  max +" = "+ maxData.first;
    }
    if(maxData.first == "-" && maxData.thirth == "-"){
        return  max +" = "+ maxData.second;
    }

    if(maxData.first == "-"){
        return  max +" = "+ maxData.second+" + "+ maxData.thirth;

    }   if(maxData.second == "-"){
        return  max +" = "+ maxData.first+" + "+ maxData.thirth;

    }

    if(maxData.thirth == "-"){
        return  max +" = "+ maxData.first+" + "+ maxData.second;

    }

    return   max +" = "+ maxData.first+" + "+ maxData.second+" + "+ maxData.thirth;

}

//console.log(Solve(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>", "<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>", "<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>", "<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>", "</table>"]));
//console.log(Solve(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>","</table>"]));
console.log(Solve(["<table>", "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>", "<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>", "<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>", "<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>","</table>"]));
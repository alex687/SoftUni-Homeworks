function Solve(input) {
    var data = {};
    //var avgVisits = {};
    function addData(name) {

    }

    for (var i = 0; i < input.length; i++) {
        var row = input[i].split("|");
        if (typeof (data[row[1].trim()]) === 'undefined') {

            data[row[1].trim()] = {students: [ row[0].trim().split(" ").filter(function(x){return x!="";}).join(" ")], sum_grades: Number(row[2].trim()), people: 1, sum_visits: Number(row[3].trim()) };
        }
        else {
            data[row[1].trim()].sum_grades += Number(row[2].trim());
            data[row[1].trim()].people++;
            data[row[1].trim()].sum_visits += Number(row[3].trim());

            if(data[row[1].trim()].students.indexOf( row[0].trim().split(" ").filter(function(x){return x!="";}).join(" ")) === -1){
                data[row[1].trim()].students.push( row[0].trim().split(" ").filter(function(x){return x!="";}).join(" "));
            }
        }
    }
    for(var key in data){
        data[key].avgGrade = Number(Number((data[key].sum_grades / data[key].people)).toFixed(2));
        data[key].avgVisits = Number(Number((data[key].sum_visits / data[key].people)).toFixed(2));
        var students = data[key].students = data[key].students.sort();
        delete (data[key].students);
        data[key].students = students;
        delete (data[key].sum_grades);
        delete (data[key].people);
        delete (data[key].sum_visits);
    }

    var sortedData = {};
    var keys = Object.keys(data);
    keys = keys.sort();
    for(var i=0; i< keys.length; i++){
        sortedData[keys[i]] = data[keys[i]];
    }
    return JSON.stringify(sortedData);
}


console.log(Solve(["Peter Nikolov | PHP  | 5.50 | 8",
    "Maria Ivanova | Java | 5.83 | 7",
    "Ivan Petrov   | PHP  | 3.00 | 2",
    "Ivan             Petrov   | C#   | 3.00 | 2",
    "Peter Nikolov | C#   | 5.50 | 8",
    "Maria Ivanova | C#   | 5.83 | 7",
    "Ivan Petrov   | C#   | 4.12 | 5",
    "Ivan Petrov   | PHP  | 3.10 | 2",
    "Peter Nikolov | Java | 6.00 | 9"]));
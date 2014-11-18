function  findYoungestPerson(persons){
        var youngest = persons[1];
        for(var key in persons){
            if(typeof (persons[key].age) === 'undefined'){
                throw "No age property";
            }
            if(persons[key].age < youngest.age){
                youngest = persons[key];
            }
        }

    return "The youngest person is "+ youngest.firstname +" "+youngest.lastname;
}

var persons = [
    { firstname : 'George', lastname: 'Kolev', age: 32},
    { firstname : 'Bay', lastname: 'Ivan', age: 81},
    { firstname : 'Baba', lastname: 'Ginka', age: 40}];
console.log(findYoungestPerson(persons));
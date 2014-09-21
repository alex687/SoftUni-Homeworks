function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    return this;
}

var people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 36));
people.push(new Person("Scott", "Hanselman", 39));
people.push(new Person("Jesse", "Johns", 57));
people.push(new Person("Jon", "Skeet", 38));

function group(array, property) {
    var result = {};
    var person;
    for (i in array) {
        person = array[i];
        if (!(property in person)) {
            continue;
        }
        if (person[property] in result) {
            result[person[property]].push(person);
        }
        else {
            result[person[property]] = [person];
        }
    }
    console.log(result);
    console.log();
}

group(people, 'firstName');
group(people, 'age');
group(people, 'lastName');
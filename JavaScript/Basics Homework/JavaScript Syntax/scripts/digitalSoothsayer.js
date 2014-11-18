function soothsayer(numbers, progLang, cities, cars) {
    var result = [];
    result[0] = numbers[(Math.random() * 5) | 0];
    result[1] = progLang[ (Math.random() * 5) | 0];
    result[2] = cities[ (Math.random() * 5) | 0];
    result[3] = cars[ (Math.random() * 5) | 0];
    return result;
}

var result = soothsayer([3, 5, 2, 7, 9], ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'], ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'], ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']);
console.log("You will work " + result[0] + " years on " + result[1] + ". You will live in " + result[2] + "and drive " + result[3]);
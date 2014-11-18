function convertKWtoHP(kw){
    return (kw / 0.745699872).toFixed(2);
}

console.log(convertKWtoHP(75))
console.log(convertKWtoHP(150))
console.log(convertKWtoHP(1000))
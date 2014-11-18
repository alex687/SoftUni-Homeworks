function playground() {
    console.log(arguments.length);

    var key;
    for (key in arguments) {
       console.log(typeof arguments[key]);
    }

    console.log(this);
}

playground(1, "adsasd", [], {});

console.log();
function testFunctionScopeCallPlayground(){
    playground("123", 2183, [1, 2, 3 ]);
}

testFunctionScopeCallPlayground();

console.log();
playground.call(null, "borko");

console.log();
playground.apply(null);
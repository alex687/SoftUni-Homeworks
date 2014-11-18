function clone(obj) {
    return JSON.parse(JSON.stringify(obj));
}
function compareObjects(obj, objCopy) {
    var result = obj == objCopy;
    console.log('a == b --> ' + result);
}

var a = {name: 'Pesho', age: 21};
var b = clone(a);
compareObjects(a, b);
var c = {name: 'Pesho', age: 21} ;
var d = c;
compareObjects(c, d);
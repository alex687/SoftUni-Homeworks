function compareAlpha(a, b) {
    var aLower = a.toLowerCase();
    var bLower = b.toLowerCase()
    if (aLower < bLower)
        return -1;
    if (aLower > bLower)
        return 1;
    return 0;
}

function displayProperties() {
    return Object.keys(document).sort().join('\n');
}

console.log(displayProperties());
document.write("<pre>" + displayProperties() + "</pre>");
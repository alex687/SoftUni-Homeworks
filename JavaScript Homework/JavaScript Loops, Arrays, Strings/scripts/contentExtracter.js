function extractContent(code) {
    var div = document.createElement('div');
    div.innerHTML = code;
    return div.innerText;
}


//For NodeJs
function extractContentNodeJs(code) {
    var lt = false , content = '';
    for (var i = 0; i < code.length; i++) {
        if (code[i] === '<') {
            lt = true;
        }
        else if (lt === false) {
            content += code[i];
        }

        if (code[i] === '>') {
            lt = false;
        }
    }

    return content;
}

//console.log(extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>"));
console.log(extractContentNodeJs("<p>Hello</p><a href='http://w3c.org'>W3C</a>"));
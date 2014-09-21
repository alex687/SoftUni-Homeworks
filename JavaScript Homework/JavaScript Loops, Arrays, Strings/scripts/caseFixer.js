function caseFixer() {
    function upcase(text) {
        return text.toUpperCase();
    }

    function lowcase(text) {
        return text.toLowerCase();
    }

    function mixcase(text) {
        var mixCaseText = '';
        for (var i = 0; i < text.length; i++) {
            var randomNumber = Math.floor((Math.random() * 100) + 1);
            if (randomNumber % 2 === 0) {
                mixCaseText += upcase(text[i]);
            }
            else {
                mixCaseText += lowcase(text[i]);
            }
        }

        return mixCaseText;
    }

    function allElemByTagAppendFunction(tagName, functionName) {
        var elements = document.getElementsByTagName(tagName);
        console.log(elements.length);
        for (var i = 0; i < elements.length; i++) {
            if (typeof( elements[i]) !== 'undefined') {
                console.log(elements[i] + "----" + elements[i].innerText);
                elements[i].innerText = functionName(elements[i].innerText);
            }
        }
    }

    allElemByTagAppendFunction('mixcase', mixcase);
    allElemByTagAppendFunction('lowcase', lowcase);
    allElemByTagAppendFunction('upcase', upcase);

}
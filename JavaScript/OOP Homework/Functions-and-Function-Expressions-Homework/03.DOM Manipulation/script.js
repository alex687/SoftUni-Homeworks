var domModule = (function () {
    function isElement(obj) {
        try {
            //Using W3 DOM2 (works for FF, Opera and Chrom)
            return obj instanceof HTMLElement;
        }
        catch (e) {
            //Browsers not supporting W3 DOM2 don't have HTMLElement and
            //an exception is thrown and we end up here. Testing some
            //properties that all elements have. (works on IE7)
            return (typeof obj === "object") &&
                (obj.nodeType === 1) && (typeof obj.style === "object") &&
                (typeof obj.ownerDocument === "object");
        }
    }

    function appendChild(childElement, selector) {
        if (!isElement(childElement)) {
            throw new TypeError("Element must be HTML element");
        }

        var elements = document.querySelectorAll(selector);

        for (var index in elements) {
            if (elements[index].nodeType === Document.ELEMENT_NODE) {
                elements[index].appendChild(childElement);
            }
        }
    }

    function removeChild(elementSelector, childElementSelector) {
        var elements = document.querySelectorAll(elementSelector);
        for (var index in elements) {
            if (elements[index].nodeType === Document.ELEMENT_NODE) {
                var childElements = elements[index].querySelectorAll(childElementSelector);
                for (var j = 0; j < childElements.length; j++) {
                    childElements[j].remove();
                }
            }
        }
    }

    function addHandler(elementSelector, eventString, eventHandlerFunction) {
        var elements = document.querySelectorAll(elementSelector);

        for (var j = 0; j < elements.length; j++) {
            elements[j].addEventListener(eventString, eventHandlerFunction);
        }
    }

    function retrieveElements(elementSelector){
        var elements = document.querySelector(elementSelector);

        return elements;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
}());

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");
// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");
// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function(){ alert("I'm a bird!") });
// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
console.log(elements);
Object.prototype.inherits = function inherits(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

Object.prototype.validateNonEmptyString = function (value, variableName) {
    if (typeof (value) !== 'string' || !value) {
        throw new Error(variableName + " should be non-empty string.");
    }
};

var ListElement = (function () {

    function ListElement(name) {
        this.setName(name);
    }

    // Get Name
    ListElement.prototype.getName = function () {
        return this._name;
    };

    // Set Name
    ListElement.prototype.setName = function (name) {
        this.validateNonEmptyString(name, "Name");

        this._name = name;
    };

    ListElement.prototype.toString = function () {
        return this.constructor.name;
    };

    return ListElement;
}());
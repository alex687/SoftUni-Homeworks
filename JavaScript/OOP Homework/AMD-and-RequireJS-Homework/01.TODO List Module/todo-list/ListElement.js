define(function () {
    function ListElement(name) {
        this.setName(name);
    }

    ListElement.prototype.validateNonEmptyString = function (value, variableName) {
        if (typeof (value) !== 'string' || !value) {
            throw new Error(variableName + " should be non-empty string.");
        }
    };

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
});
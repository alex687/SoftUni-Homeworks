Object.prototype.validateNonEmptyString = function (value, variableName) {
    if (typeof (value) !== 'string' || !value) {
        throw new Error(variableName + " should be non-empty string.");
    }
}

Object.prototype.validateIntegerRange = function (value, variableName, minValue, maxValue) {
    if (typeof (value) !== 'number') {
        throw new Error(variableName + " should be a number.");
    }
    if (value !== parseInt(value, 10)) {
        throw new Error(variableName + " should be integer.");
    }
    if (value < minValue || value > maxValue) {
        throw new Error(variableName + " should be integer in the range [" +
        minValue + "..." + maxValue + "].");
    }
}

Object.prototype.validateBoolean = function (value, variableName) {
    if (typeof (value) !== 'boolean') {
        throw new Error(variableName + " should be a boolean value.");
    }
}

Object.prototype.validateNonEmptyObject = function (value, className, variableName) {
    if (!(value instanceof className)) {
        throw new Error(variableName + " should be non-empty " +
        className.prototype.constructor.name + ".");
    }
}

    
var specialConsole = (function specialConsole() {

    function writeLine() {
        if (arguments.length > 2) {
            console.log(writeLineWithArguments(arguments));
        }
        else {
            console.log(writeLineWithoutArguments(arguments));
        }
    }

    function writeError() {
        if (arguments.length > 2) {
            console.error(writeLineWithArguments(arguments));
        }
        else {
            console.error(writeLineWithoutArguments(arguments));
        }
    }

    function writeWarning() {
        if (arguments.length > 2) {
            console.warn(writeLineWithArguments(arguments));
        }
        else {
            console.warn(writeLineWithoutArguments(arguments));
        }
    }

    function writeLineWithoutArguments(args) {
        var strResult = args[0].toString();
        return strResult;
    }

    function writeLineWithArguments(arguments) {
        var re = /{{1}[0-9]}{1}/g;
        var strResult = "";
        var lastIndexOccurrence = 0;
        var match;
        var argumentsCounter = 1;
        while (match = re.exec(arguments[0])) {
            strResult += arguments[0].substr(lastIndexOccurrence, match.index - lastIndexOccurrence);
            strResult += arguments[argumentsCounter];
            argumentsCounter++;
            lastIndexOccurrence = match.index + match[0].length;
        }

        return strResult;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

})();

specialConsole.writeLine("Line: single Line");
specialConsole.writeLine("Line: {0}, {1}, {2}", "line1", "line2", "line3");
specialConsole.writeError("Error: single Error");
specialConsole.writeError("Error: {0}, {1}, {2}, {3}, {4}", "Err1", "Err2", "Err3", "Err4", "Err5");
specialConsole.writeWarning("Warning: single Warning");
specialConsole.writeWarning("Warning: {0} {1}", "Warn1", "Warn2");
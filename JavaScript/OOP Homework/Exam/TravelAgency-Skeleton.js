function processTravelAgencyCommands(commands) {
    'use strict';

    Object.prototype.inherits = function inherits(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    Date.prototype.validateDate = function validateDate() {
        if( this == "Invalid Date"){
            throw new Error("Invalid Date");
        }
        var y = this.getFullYear();
        var m = this.getMonth() + 1;
        var d = this.getDate();

        var date = new Date(y, m - 1, d);
        var convertedDate =
            "" + date.getFullYear() + (date.getMonth() + 1) + date.getDate();
        var givenDate = "" + y + m + d;
        if (( givenDate !== convertedDate)) {
            throw new Error("Invalid Date");
        }
    };

    Date.prototype.toTravelString = function () {
      return formatDate(this);
    };

    Object.prototype.validateNonEmptyObject = function (value, className, variableName) {
        if (!(value instanceof className)) {
            throw new Error(variableName + " should be non-empty " +
            className.prototype.constructor.name + ".");
        }
    };

    Object.prototype.validateFloatRange = function (value, variableName, minValue, maxValue) {
       if (typeof (value) !== 'number') {
            throw new Error(variableName + " should be a number.");
        }
        if (value !== parseFloat(value)) {
            throw new Error(variableName + " should be float.");
        }
        if (value < minValue || value > maxValue) {
            throw new Error(variableName + " should be integer in the range [" +
            minValue + "..." + maxValue + "].");
        }
    };

    Object.prototype.validateNonEmptyString = function (value, variableName) {
        if (typeof (value) !== 'string' || !(/\S/.test(value)) ) {
            throw new Error(variableName + " should be non-empty string.");
        }
   };

    var Models = (function () {
        var Destination = (function () {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function () {
                return this._location;
            };

            Destination.prototype.setLocation = function (location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            };

            Destination.prototype.getLandmark = function () {
                return this._landmark;
            };

            Destination.prototype.setLandmark = function (landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            };

            Destination.prototype.toString = function () {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            };

            return Destination;
        }());

        var Travel = (function () {

            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throw new Error("Can't instantiate abstract class Travel.");
                }

                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }

            // Get Name
            Travel.prototype.getName = function () {
                return this._name;
            };

            // Set Name
            Travel.prototype.setName = function (name) {
                this.validateNonEmptyString(name, "name");
                this._name = name;
            };

            // Get StartDate
            Travel.prototype.getStartDate = function () {
                return this._startDate;
            };

            // Set StartDate
            Travel.prototype.setStartDate = function (startDate) {
                startDate.validateDate();

                this._startDate = startDate;
            };

            // Get EndDate
            Travel.prototype.getEndDate = function () {
                return this._endDate;
            };

            // Set EndDate
            Travel.prototype.setEndDate = function (endDate) {
                endDate.validateDate();

                this._endDate = endDate;
            };

            // Get Price
            Travel.prototype.getPrice = function () {
                return this._price;
            };

            // Set Price
            Travel.prototype.setPrice = function (price) {
                this.validateFloatRange(price, "price", 0, Number.MAX_VALUE);

                this._price = price;
            };

            Travel.prototype.toString = function () {
                var startDate = this.getStartDate().toTravelString();
                var endDate = this.getEndDate().toTravelString();

                return "name=" + this.getName() + ",start-date=" + startDate + ",end-date=" + endDate + ",price=" + this.getPrice().toFixed(2);
            };

            return Travel;
        }());

        var Excursion = (function () {

            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);
                this.setTransport(transport);

                this._destinations = [];
            }

            Excursion.inherits(Travel);

            // Get Transport
            Excursion.prototype.getTransport = function () {
                return this._transport;
            };

            // Set Transport
            Excursion.prototype.setTransport = function (transport) {
                this.validateNonEmptyString(transport, "transport");

                this._transport = transport;
            };

            Excursion.prototype.addDestination = function (destination) {
                this.validateNonEmptyObject(destination, Destination, "destination");

                this._destinations.push(destination);
            };

            Excursion.prototype.removeDestination = function (destination) {
                var index = this._destinations.indexOf(destination);
                if (index > -1) {
                    this._destinations.splice(index, 1);
                }
                else {
                    throw new Error("No such destination");
                }
            };

            Excursion.prototype.getDestinations = function () {
                return this._destinations;
            };

            Excursion.prototype._destinationsToString = function () {
                var destinationsStr = "";
                var destinations = this.getDestinations();

                for (var i = 0; i < destinations.length; i++) {
                    destinationsStr += destinations[i] + ";";
                }

                if (!destinationsStr) {
                    destinationsStr = "-";
                }
                else {
                    destinationsStr = destinationsStr.substr(0, destinationsStr.length - 1);
                }

                return destinationsStr;
            };

            Excursion.prototype.toString = function () {
                var baseString = Travel.prototype.toString.call(this);
                var destinationsStr = this._destinationsToString();
                return " * Excursion: " + baseString + ",transport=" + this.getTransport() + "\n" +
                    " ** Destinations: " + destinationsStr;
            };

            return Excursion;
        }());


        var Vacation = (function () {

            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.call(this, name, startDate, endDate, price);

                this.setLocation(location);
                if (typeof(accommodation) !== "undefined") {
                    this.setAccommodation(accommodation);
                }
            }

            Vacation.inherits(Travel);

            // Get Location
            Vacation.prototype.getLocation = function () {
                return this._location;
            };

            // Set Location
            Vacation.prototype.setLocation = function (location) {
                this.validateNonEmptyString(location, "location");

                this._location = location;
            };

            // Get Accommodation
            Vacation.prototype.getAccommodation = function () {
                return this._accommodation;
            };

            // Set Accommodation
            Vacation.prototype.setAccommodation = function (accommodation) {
                this.validateNonEmptyString(accommodation, "accommodation");

                this._accommodation = accommodation;
            };

            Vacation.prototype.toString = function () {
                var baseString = Travel.prototype.toString.call(this);
                var accommodationString = typeof (this.getAccommodation()) !== "undefined" ? ",accommodation=" + this.getAccommodation() : "";

                return " * Vacation: " + baseString + ",location=" + this.getLocation() + accommodationString;
            };

            return Vacation;
        }());

        var Cruise = (function () {

            function Cruise(name, startDate, endDate, price, startDock) {
                Excursion.call(this, name, startDate, endDate, price, "cruise liner");

                if (typeof(startDock) !== "undefined") {
                    this.setStartDock(startDock);
                }
            }

            Cruise.inherits(Excursion);

            // Get StartDock
            Cruise.prototype.getStartDock = function () {
                return this._startDock;
            };

            // Set StartDock
            Cruise.prototype.setStartDock = function (startDock) {
                this.validateNonEmptyString(startDock, "startDock");
                this._startDock = startDock;
            };

            Cruise.prototype.toString = function () {
                var baseTravelString = Travel.prototype.toString.call(this);
                var destinationsStr = Excursion.prototype._destinationsToString.call(this);
                return " * Cruise: " + baseTravelString + ",transport=" + this.getTransport() + "\n" +
                    " ** Destinations: " + destinationsStr;
            };

            return Cruise;
        }());

        return {
            Destination: Destination,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise,
            Travel: Travel
        };
    }());

    var TravellingManager = (function () {
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            function processFilterTravelsCommand(command)
            {
                var minPrice = Number(command['price-min']);
                var maxPrice = Number(command['price-max']);

            //    Object.validateFloatRange(maxPrice, "maxPrice", minPrice, Math.MAX_VALUE);
              //  Object.validateFloatRange(minPrice, "minPrice", 0, maxPrice);

                var selectedTravells;

                switch (command["type"]) {
                    case "excursion":
                        selectedTravells = filterTravels(Models.Excursion, minPrice, maxPrice);
                        break;
                    case "vacation":
                        selectedTravells = filterTravels(Models.Vacation, minPrice, maxPrice);
                        break;
                    case "cruise":
                        selectedTravells = filterTravels(Models.Cruise, minPrice, maxPrice);
                        break;
                    case "all":
                        selectedTravells = filterTravels(Models.Travel, minPrice, maxPrice);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                selectedTravells.sort(function (a, b) {
                    var result;
                    if(a.getStartDate().getTime() > b.getStartDate().getTime()){
                        result = 1;
                    }
                    else
                    if(a.getStartDate().getTime() < b.getStartDate().getTime()){
                        result = -1;
                    }
                    else
                    {
                        result = a.getName().localeCompare(b.getName());
                    }
                    return result;
                });

                return formatTravelsQuery(selectedTravells);
            }

            function filterTravels(TravelType, minPrice, maxPrice){
                return _travels.filter(function (travel) {
                    return travel.getPrice() >= minPrice && travel.getPrice() <= maxPrice &&
                    travel instanceof TravelType;
                });
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand
            };
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                //console.log(e);
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function () {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function (line) {
            arr.push(line);
        }).on('close', function () {
            console.log(processTravelAgencyCommands(arr));
        });
    }
})();
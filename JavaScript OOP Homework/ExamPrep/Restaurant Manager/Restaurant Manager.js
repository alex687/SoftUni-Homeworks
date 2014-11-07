    function processRestaurantManagerCommands(commands) {
        'use strict';

        var RestaurantEngine = (function () {
            var _restaurants, _recipes;

            Object.prototype.inherits = function inherits(parent) {
                this.prototype = Object.create(parent.prototype);
                this.prototype.constructor = this;
            };

            function initialize() {
                _restaurants = [];
                _recipes = [];
            }

            var Restaurant = (function () {

                function Restaurant(name, location) {
                    this.setName(name);
                    this.setLocation(location);
                    this._recipies = [];
                }

                // Get Name
                Restaurant.prototype.getName = function () {
                    return this._name;
                };

                // Set Name
                Restaurant.prototype.setName = function (name) {
                    this._name = name;
                };

                // Get Location
                Restaurant.prototype.getLocation = function () {
                    return this._location;
                };

                // Set Location
                Restaurant.prototype.setLocation = function (location) {
                    this._location = location;
                };

                Restaurant.prototype.addRecipe = function (recipe) {
                    this._recipies.push(recipe);
                };

                Restaurant.prototype.removeRecipe = function (recipe) {
                    var index = this._recipies.indexOf(recipe);
                    if (index > -1) {
                        this._recipies.splice(index, 1);
                    }
                };

                Restaurant.prototype.printRestaurantMenu = function () {
                    var str = "";
                    str += "***** " + this.getName() + " - " + this.getLocation() + " *****" + "\r\n";
                    if (this._recipies.length === 0) {
                        str += "No recipes... yet" + "\r\n";
                    }
                    else {

                         var categories = {};
                        categories["DRINKS"] = this._recipies.filter(function (r) {
                            return r instanceof  Drink;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["SALADS"] = this._recipies.filter(function (r) {
                            return r instanceof  Salad;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["MAIN COURSES"] = this._recipies.filter(function (r) {
                            return r instanceof  MainCourse;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["DESSERTS"] = this._recipies.filter(function (r) {
                            return r instanceof  Dessert;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        for (var index in categories) {
                            if (categories[index].length > 0 && typeof(categories[index]) === 'object') {
                                str += "~~~~~ " + index + " ~~~~~" + "\r\n";
                                for (var i = 0; i < categories[index].length; i++) {
                                    str += categories[index][i];
                                }
                            }
                        }
                    }

                    return str;
                };

              return Restaurant;
            }());

            var Recipe = (function () {

                function Recipe(name, price, calories, quantity, unit, timeToPrepare) {
                    if (this.constructor === Recipe) {
                        throw new Error("Can't instantiate abstract class Recipe.");
                    }

                    this.setName(name);
                    this.setPrice(price);
                    this.setCalories(calories);
                    this.setQuantity(quantity);
                    this.setUnit(unit);
                    this.setTimeToPrepare(timeToPrepare);
                }

                Recipe.prototype.units = {grams: 'g', milliliters: 'ml'};

                // Get Name
                Recipe.prototype.getName = function () {
                    return this._name;
                };

                // Set Name
                Recipe.prototype.setName = function (name) {
                    this._name = name;
                };

                // Get Price
                Recipe.prototype.getPrice = function () {
                    return this._price.toFixed(2);
                };

                // Set Price
                Recipe.prototype.setPrice = function (price) {
                    this._price = price;
                };

                // Get Calories
                Recipe.prototype.getCalories = function () {
                    return this._calories;
                };

                // Set Calories
                Recipe.prototype.setCalories = function (calories) {
                    this._calories = calories;
                };

                // Get Quantity
                Recipe.prototype.getQuantity = function () {
                    return this._quantity;
                };

                // Set Quantity
                Recipe.prototype.setQuantity = function (quantity) {
                    this._quantity = quantity;
                };

                // Get Unit
                Recipe.prototype.getUnit = function () {
                    return this._unit;
                };

                // Set Unit
                Recipe.prototype.setUnit = function (unit) {
                    this._unit = unit;
                };

                // Get TimeToPrepare
                Recipe.prototype.getTimeToPrepare = function () {
                    return this._timeToPrepare;
                };

                // Set TimeToPrepare
                Recipe.prototype.setTimeToPrepare = function (timeToPrepare) {
                    this._timeToPrepare = timeToPrepare;
                };

                Recipe.prototype.toString = function () {
                    return "==  " + this.getName() + " == $" + this.getPrice() + "\r\n" +
                        "Per serving: " + this.getQuantity() + " " + this.getUnit() + ", " + this.getCalories() + " kcal" + "\r\n" +
                        "Ready in " + this.getTimeToPrepare() + " minutes";

                };

                return Recipe;
            }());

            var Drink = (function () {

                function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                    Recipe.call(this, name, price, calories, quantity, Recipe.prototype.units.milliliters, timeToPrepare);

                    this.setIsCarbonated(isCarbonated);
                }

                Drink.inherits(Recipe);

                // Get IsCarbonated
                Drink.prototype.getIsCarbonated = function () {
                    return this._isCarbonated;
                };

                // Set IsCarbonated
                Drink.prototype.setIsCarbonated = function (isCarbonated) {
                    this._isCarbonated = isCarbonated;
                };

                Drink.prototype.toString = function () {
                    var base, isCarbonatedString;
                    base = Recipe.prototype.toString.call(this);

                    isCarbonatedString = this.getIsCarbonated() ? "yes" : "no";

                    return base + "\r\n" +
                        "Carbonated: " + isCarbonatedString + "\r\n";
                };

                return Drink;
            }());

            var Meal = (function () {

                function Meal(name, price, calories, quantity, timeToPrepare, isVegan) {
                    if (this.constructor === Meal) {
                        throw new Error("Can't instantiate abstract class Meal.");
                    }

                    Recipe.call(this, name, price, calories, quantity, Recipe.prototype.units.grams, timeToPrepare);
                    this.setIsVegan(isVegan);
                }

                Meal.inherits(Recipe);

                // Get IsVegan
                Meal.prototype.getIsVegan = function () {
                    return this._isVegan;
                };

                // Set IsVegan
                Meal.prototype.setIsVegan = function (isVegan) {
                    this._isVegan = isVegan;
                };

                Meal.prototype.toggleVegan = function () {
                    if (this.getIsVegan()) {
                        this.setIsVegan(false);
                    }
                    else {
                        this.setIsVegan(true);
                    }
                };

                Meal.prototype.toString = function () {
                    var base, isVeganString;
                    base = Recipe.prototype.toString.call(this);
                    isVeganString = this.getIsVegan() ? "[VEGAN] " : "";

                    return isVeganString + base;
                };

                return Meal;
            }());

            var Dessert = (function () {

                function Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                    Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);

                    this.setHasSugar(true);
                }

                Dessert.inherits(Meal);

                // Get HasSugar
                Dessert.prototype.getHasSugar = function () {
                    return this._withSugar;
                };

                // Set HasSugar
                Dessert.prototype.setHasSugar = function (withSugar) {
                    this._withSugar = withSugar;
                };

                Dessert.prototype.toggleSugar = function () {
                    this.setHasSugar(!this.getHasSugar());
                };


                Dessert.prototype.toString = function () {
                    var base, hasSugarString;
                    base = Meal.prototype.toString.call(this);
                    hasSugarString = this.getHasSugar() ? "" : "[NO SUGAR] ";

                    return hasSugarString + base + "\r\n";
                };

                return Dessert;
            }());

            var MainCourse = (function () {

                function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                    Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);

                    this.setType(type);
                }

                MainCourse.inherits(Meal);

                // Get Type
                MainCourse.prototype.getType = function () {
                    return this._type;
                };

                // Set Type
                MainCourse.prototype.setType = function (type) {
                    this._type = type;
                };

                MainCourse.prototype.toString = function () {
                    var base = Meal.prototype.toString.call(this);

                    return base + "\r\n" +
                        "Type: " + this.getType() + "\r\n";
                };

                return MainCourse;
            }());

            var Salad = (function () {

                function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                    Meal.call(this, name, price, calories, quantity, timeToPrepare, true);

                    this.setContainsPasta.call(this, containsPasta);
                }

                Salad.inherits(Meal);

                // Get ContainsPasta
                Salad.prototype.getContainsPasta = function () {
                    return this._containsPasta;
                };

                // Set ContainsPasta
                Salad.prototype.setContainsPasta = function (containsPasta) {
                    this._containsPasta = containsPasta;
                };

                Salad.prototype.toString = function () {
                    var base, containsPastaString;
                    base = Meal.prototype.toString.call(this);
                    containsPastaString = this.getContainsPasta() ? "yes" : "no";

                    return base + "\r\n" +
                        "Contains pasta: " + containsPastaString + "\r\n";
                };

                return Salad;
            }());

            var Command = (function () {
                var COMMAND_NAME_SEPARATOR = '(';
                var COMMAND_PARAMETER_SEPARATOR = ';';
                var COMMAND_VALUE_SEPARATOR = '=';

                function Command(input) {
                    this._params = {};
                    var parametersBeginning = input.indexOf(COMMAND_NAME_SEPARATOR);
                    this._name = input.substring(0, parametersBeginning).trim();

                    var parametersKeysAndValues = input.substring(parametersBeginning + 1, input.length - 1)
                        .split(COMMAND_PARAMETER_SEPARATOR);

                    for (var i = 0; i < parametersKeysAndValues.length; i++) {
                        var split = parametersKeysAndValues[i].split(COMMAND_VALUE_SEPARATOR);

                        this._params[split[0]] = split[1];
                    }
                }

                return Command;
            }());

            function createRestaurant(name, location) {
                _restaurants[name] = new Restaurant(name, location);
                return "Restaurant " + name + " created\n";
            }

            function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
                return "Recipe " + name + " created\n";
            }

            function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
                return "Recipe " + name + " created\n";
            }

            function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
                return "Recipe " + name + " created\n";
            }

            function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
                return "Recipe " + name + " created\n";
            }

            function toggleSugar(name) {
                var recipe;

                if (!_recipes.hasOwnProperty(name)) {
                    throw new Error("The recipe " + name + " does not exist");
                }

                recipe = _recipes[name];
                if (recipe instanceof Dessert) {
                    recipe.toggleSugar();
                    return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
                } else {
                    return "The command ToggleSugar is not applicable to recipe " + name + "\n";
                }
            }

            function toggleVegan(name) {
                var recipe;

                if (!_recipes.hasOwnProperty(name)) {
                    throw new Error("The recipe " + name + " does not exist");
                }

                recipe = _recipes[name];
                if (recipe instanceof Meal) {
                    recipe.toggleVegan();
                    return "Command ToggleVegan executed successfully. New value: " +
                        recipe._isVegan.toString().toLowerCase() + "\n";
                } else {
                    return "The command ToggleVegan is not applicable to recipe " + name + "\n";
                }
            }

            function printRestaurantMenu(name) {
                var restaurant;
                if (!_restaurants.hasOwnProperty(name)) {
                    throw new Error("The restaurant " + name + " does not exist");
                }

                restaurant = _restaurants[name];
                return restaurant.printRestaurantMenu();
            }

            function addRecipeToRestaurant(restaurantName, recipeName) {
                var restaurant, recipe;

                if (!_restaurants.hasOwnProperty(restaurantName)) {
                    throw new Error("The restaurant " + restaurantName + " does not exist");
                }
                if (!_recipes.hasOwnProperty(recipeName)) {
                    throw new Error("The recipe " + recipeName + " does not exist");
                }

                restaurant = _restaurants[restaurantName];
                recipe = _recipes[recipeName];
                restaurant.addRecipe(recipe);
                return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
            }

            function removeRecipeFromRestaurant(restaurantName, recipeName) {
                var restaurant, recipe;

                if (!_recipes.hasOwnProperty(recipeName)) {
                    throw new Error("The recipe " + recipeName + " does not exist");
                }
                if (!_restaurants.hasOwnProperty(restaurantName)) {
                    throw new Error("The restaurant " + restaurantName + " does not exist");
                }

                restaurant = _restaurants[restaurantName];
                recipe = _recipes[recipeName];
                restaurant.removeRecipe(recipe);
                return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
            }

            function executeCommand(commandLine) {
                var cmd, params, result;
                cmd = new Command(commandLine);
                params = cmd._params;

                switch (cmd._name) {
                    case 'CreateRestaurant':
                        result = createRestaurant(params["name"], params["location"]);
                        break;
                    case 'CreateDrink':
                        result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                            parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                        break;
                    case 'CreateSalad':
                        result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                            parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                        break;
                    case "CreateMainCourse":
                        result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                            parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                        break;
                    case "CreateDessert":
                        result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                            parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                        break;
                    case "ToggleSugar":
                        result = toggleSugar(params["name"]);
                        break;
                    case "ToggleVegan":
                        result = toggleVegan(params["name"]);
                        break;
                    case "AddRecipeToRestaurant":
                        result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                        break;
                    case "RemoveRecipeFromRestaurant":
                        result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                        break;
                    case "PrintRestaurantMenu":
                        result = printRestaurantMenu(params["name"]);
                        break;
                    default:
                        throw new Error('Invalid command name: ' + cmd._name);
                }

                return result;
            }

            function parseBoolean(value) {
                switch (value) {
                    case "yes":
                        return true;
                    case "no":
                        return false;
                    default:
                        throw new Error("Invalid boolean value: " + value);
                }
            }

            return {
                initialize: initialize,
                executeCommand: executeCommand
            };
        }());


        // Process the input commands and return the results
        var results = '';
        RestaurantEngine.initialize();
        commands.forEach(function (cmd) {
            if (cmd != "") {
                try {
                    var cmdResult = RestaurantEngine.executeCommand(cmd);
                    results += cmdResult;
                } catch (err) {
                    results += err.message + "\n";
                }
            }
        });

        return results.trim();
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
                if (line == "122") {
                    console.log(processRestaurantManagerCommands(arr));
                }
                arr.push(line);
            }).on('close', function () {
                console.log(processRestaurantManagerCommands(arr));
            });
        }
    })();

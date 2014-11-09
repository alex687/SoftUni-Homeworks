var Factory = Factory || {};
(function (Factory) {
    function Container(name) {
        ListElement.call(this, name);
        this._sections = [];
    }

    Container.inherits(ListElement);

    Container.prototype.addSection = function (section) {
        if (!(section instanceof  Factory.Section)) {
            throw new Error("Invalid Section");
        }

        this._sections.push(section);
    };

    Container.prototype.getSections = function () {
        return this._sections;
    };
    /*
     Container.prototype.addToDOM = function (parentHtmlElement) {

     };

     */

    Container.prototype.toString = function () {
        return "Container : " + this.getName();
    };

    Factory.Container = Container;
})(Factory);
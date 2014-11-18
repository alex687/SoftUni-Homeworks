define(["ListElement", "Section"], function (ListElement, Section) {
    function Container(name) {
        ListElement.call(this, name);
        this._sections = [];
    }

    Container.inherits(ListElement);

    Container.prototype.addSection = function (section) {
        if (!(section instanceof  Section)) {
            throw new Error("Invalid Section");
        }

        this._sections.push(section);
    };

    Container.prototype.getSections = function () {
        return this._sections;
    };

    Container.prototype.toString = function () {
        return "Container : " + this.getName();
    };

    return Container;
});
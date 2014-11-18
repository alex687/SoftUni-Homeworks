define(["Item", "ListElement"], function (Item, ListElement) {
    function Section(name) {
        ListElement.call(this, name);
        this._items = [];
    }

    Section.inherits(ListElement);

    Section.prototype.addItem = function (item) {
        if (!(item instanceof  Item)) {
            throw new Error("Invalid Item");
        }

        this._items.push(item);
    };

    Section.prototype.toString = function () {
        return "Section : " + this.getName();
    };

    return Section;
});

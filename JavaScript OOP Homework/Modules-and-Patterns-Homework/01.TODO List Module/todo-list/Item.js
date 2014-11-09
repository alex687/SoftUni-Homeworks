var Factory = Factory || {};
(function (Factory) {
    function Item(name) {
        ListElement.call(this, name);
    }

    Item.inherits(ListElement);

    Item.prototype.toString = function () {
        return "Item : " + this.getName();
    };

    Factory.getContainer = function (name) {
        return new Item(name);
    };

    Factory.Item = Item;
})(Factory);

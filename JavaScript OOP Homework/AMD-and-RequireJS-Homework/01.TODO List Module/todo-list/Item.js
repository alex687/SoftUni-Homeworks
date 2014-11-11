define(["ListElement"],function (ListElement) {
    function Item(name) {
        ListElement.call(this, name);
    }

    Item.inherits(ListElement);

    Item.prototype.toString = function () {
        return "Item : " + this.getName();
    };

   return Item;
});

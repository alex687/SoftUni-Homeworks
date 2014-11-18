var ItemRenderer = (function () {
    function ItemRenderer(item) {
        if (!(item instanceof Factory.Item)) {
            throw new Error("Invalid Item");
        }

        this._item = item;
    }

    ItemRenderer.prototype._generateHtml = function () {
        var item = document.createElement("div");

        var input = document.createElement("input");
        input.type = "checkbox";
        input.id = this._item;

        var label = document.createElement("label");
        label.innerHTML = this._item.getName();

        item.appendChild(input);
        item.appendChild(label);

        return item;
    };

    ItemRenderer.prototype.addToDOM = function (parentHtmlElement) {
        parentHtmlElement.appendChild(this._generateHtml());
    };

    return ItemRenderer;
}());
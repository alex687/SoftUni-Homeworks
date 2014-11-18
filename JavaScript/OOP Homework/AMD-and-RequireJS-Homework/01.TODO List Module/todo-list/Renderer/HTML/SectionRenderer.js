define(["Factory", "ItemRenderer"], function (Factory, ItemRenderer) {
    function SectionRenderer(section) {
        if (!(section instanceof Factory.Section)) {
            throw new Error("Invalid Section");
        }

        this._section = section;
        var self = this;

        SectionRenderer.prototype._addNewItem = function () {
            var name = this.parentNode.querySelector("input[name='itemName']").value;
            var item = new Factory.Item(name);
            self._section.addItem(item);

            var itemContainer = this.parentNode.parentNode.querySelector(".itemContainer");
            var itemRenderer = new ItemRenderer(item);
            itemRenderer.addToDOM(itemContainer);
        };
    }

    SectionRenderer.prototype._generateHtml = function () {
        var header = document.createElement("h3");
        header.innerHTML = this._section.getName();

        var itemDiv = document.createElement("div");
        itemDiv.appendChild(header);
        itemDiv.className = "itemContainer";

        var input = document.createElement("input");
        input.type = "text";
        input.placeholder = 'Add item...';
        input.name = 'itemName';

        var button = document.createElement("button");
        button.innerHTML = '+';
        button.name = 'addItemButton';
        button.onclick = this._addNewItem;

        var errorMessage = document.createElement("div");
        errorMessage.setAttribute("name", "errorSection");
        errorMessage.className = "hideError";
        errorMessage.innerHTML = "Enter item title.";


        var buttonDiv = document.createElement("div");
        buttonDiv.appendChild(input);
        buttonDiv.appendChild(button);
        buttonDiv.appendChild(errorMessage);

        var section = document.createElement("article");

        section.appendChild(itemDiv);
        section.appendChild(buttonDiv);

        return section;
    };

    SectionRenderer.prototype.addToDOM = function (parentHtmlElement) {
        parentHtmlElement.appendChild(this._generateHtml());
    };

    return SectionRenderer;
});
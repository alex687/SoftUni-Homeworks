(function () {
    Object.prototype.inherits = function inherits(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    require.config({
        paths: {
            "Factory": "todo-list/Factory",
            "SectionRenderer": "todo-list/Renderer/HTML/SectionRenderer",
            "ContainerRenderer": "todo-list/Renderer/HTML/ContainerRenderer",
            "ItemRenderer": "todo-list/Renderer/HTML/ItemRenderer",
            "ListElement": "todo-list/ListElement",
            "Item": "todo-list/Item",
            "Section": "todo-list/Section",
            "Container": "todo-list/Container"
        }
    });

    require(["Factory", "ContainerRenderer"], function (Factory, ContainerRenderer) {
        var container =  new Factory.Container("TODO List");

        var containerRenderer = new ContainerRenderer(container);
        containerRenderer.addToDOM(document.body);
    });
}());

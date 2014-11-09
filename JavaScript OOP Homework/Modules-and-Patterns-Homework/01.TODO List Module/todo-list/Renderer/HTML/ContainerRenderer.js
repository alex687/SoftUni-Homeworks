var ContainerRenderer = (function () {
        function ContainerRenderer(container) {
            if (!(container instanceof Factory.Container)) {
                throw new Error("Invalid container");
            }

            this._container = container;

            var self = this;

            ContainerRenderer.prototype._addNewSection = function () {
                var name = this.parentNode.querySelector("input[name='sectionTitle']").value;
                var section = new Factory.Section(name);
                self._container.addSection(section);

                var sectionContainer = this.parentNode.querySelector(".sectionsContainer");
                var sectionRenderer = new SectionRenderer(section);
                sectionRenderer.addToDOM(sectionContainer);
            };
        }

        ContainerRenderer.prototype._generateHtml = function () {
            var header = document.createElement("h1");
            header.innerHTML = this._container.getName();

            var div = document.createElement("div");
            div.className = "sectionsContainer";
            div.appendChild(header);

            var input = document.createElement("input");
            input.type = "text";
            input.placeholder = 'Title';
            input.name = 'sectionTitle';

            var button = document.createElement("button");
            button.innerHTML = 'New Section';
            button.name = 'addSectionButton';
            button.onclick = this._addNewSection;

            var errorMessage = document.createElement("div");
            errorMessage.setAttribute("name", "errorContainer");
            errorMessage.className = "hideError";
            errorMessage.innerHTML = "Enter section title.";

            var container = document.createElement("section");

            container.appendChild(header);
            container.appendChild(div);
            container.appendChild(input);
            container.appendChild(button);
            container.appendChild(errorMessage);

            return container;
        };

        ContainerRenderer.prototype.addToDOM = function (parentHtmlElement) {
            this._parrent = parentHtmlElement;
            parentHtmlElement.appendChild(this._generateHtml());
        };

        return ContainerRenderer;
    }()
    )
    ;
function traverse(selector) {
    var nodes = document.querySelectorAll(selector);
    for (var index in nodes) {
        if (nodes[index].nodeType === document.ELEMENT_NODE) {
            traverseNode(nodes[index], '');
        }
    }

    function traverseNode(node, spacing) {
        function getAttributes(child) {
            var attributes = "";

            if (child.getAttribute("id")) {
                attributes += " id=" + child.id;
            }

            if (child.getAttribute("class")) {
                attributes += " class=" + child.getAttribute("class");
            }

            return attributes;
        }

        spacing = spacing || '  ';

        for (var i = 0; i < node.childNodes.length; i += 1) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                console.log(spacing + child.nodeName + ":" + getAttributes(child));

                traverseNode(child, spacing + '  ');
            }
        }
    }
}


var selector = ".birds";
traverse(selector);
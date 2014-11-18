function replaceATag() {
    while (document.getElementsByTagName('a').length > 0) {
        var allTags = document.getElementsByTagName('a');
        for (var key in allTags) {
            var tag = allTags[key];
            var code = tag.outerHTML;
            if (typeof(code) !== 'undefined') {
                code = code.substring(2, code.length - 4);
                code = code.replace('>', ']');
                tag.outerHTML = "[URL " + code + "[/URL]";
            }
        }
    }
}
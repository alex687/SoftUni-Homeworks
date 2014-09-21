<?php
session_start();
if (empty($_SESSION['tags']) || empty($_SESSION['count'])) {
    $_SESSION['tags'] = array();
    $_SESSION['count'] = 0;
}

$htmlTags = array(
    'a', 'abbr', 'acronym', 'address', 'applet', 'area', 'article', 'aside', 'audio', 'b', 'base', 'basefont', 'bdi', 'bdo', 'bgsound', 'big',
    'blink', 'blockquote', 'body', 'br', 'button', 'canvas', 'caption', 'center', 'cite', 'code', 'col', 'colgroup', 'content', 'data', 'datalist',
    'dd', 'decorator', 'del', 'details', 'dfn', 'dialog', 'dir', 'div', 'dl', 'dt', 'element', 'em', 'embed', 'fieldset', 'figcaption',
    'figure', 'font', 'footer', 'form', 'frame', 'frameset', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'head', 'header', 'hgroup', 'hr',
    'html', 'i', 'iframe', 'img', 'input', 'ins', 'isindex', 'kbd', 'keygen', 'label', 'legend', 'li', 'link', 'listing', 'main',
    'map', 'mark', 'marquee', 'menu', 'menuitem', 'meta', 'meter', 'nav', 'nobr', 'noframes', 'noscript', 'object', 'ol', 'optgroup',
    'option', 'output', 'p', 'param', 'picture', 'plaintext', 'pre', 'progress', 'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script',
    'section', 'select', 'shadow', 'small', 'source', 'spacer', 'span', 'strike', 'strong', 'style', 'sub', 'summary', 'sup', 'table',
    'tbody', 'td', 'template', 'textarea', 'tfoot', 'th', 'thead', 'time', 'title', 'tr', 'track', 'tt', 'u', 'ul', 'var', 'video',
    'wbr', 'xmp'
);
?>

<!DOCTYPE html>
<html>
<head>
    <title>Problem 4.	HTML Tags Counter</title>
</head>
<body>
<form action="HTMLTagsCounter.php" method="POST">
    <p>Enter HTML Tags:</p>
    <input type="text" name="tag"/>
    <input type="submit" value="Submit"/>
    <?php
    if (isset($_POST['tag'])) {
        $tag = $_POST['tag'];
        if (in_array ($tag, $htmlTags) && empty($_SESSION['tags'][$tag])) {
            $_SESSION['count']++;
            array_push($_SESSION['tags'], $tag);
            echo "<p>Valid tag</p>";
        }
        else{
            echo "<p>Invalid tag</p>";
        }
        echo "Score: ".  $_SESSION['count'];
    }

    ?>
</form>
</body>
</html>

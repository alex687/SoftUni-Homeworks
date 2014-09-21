<?php
$html = $_GET['html'];
$lines = preg_split("/[\n]+/", $html);
// var_dump($lines);
$semanticTags = array("main", "article", "nav", "header", "section", "aside", "footer");

function checkForOpenTagAndFormatIt($line)
{
    global $semanticTags;
    $startIndex = strpos($line, "<div");
    /// IF ERRROR <    div
    if ($startIndex === false) {
        return false;
    }

    preg_match_all("/([A-Za-z-]+)\s*=\s*\"([^\"]*)\"/", $line, $attributes, PREG_SET_ORDER);
    $tagNewName = "";
    $hasAsemanticTag = false;
    $modifiedAttributes = array();
    foreach ($attributes as $attribute) {
        $newTag = "";
        if ($attribute[1] == "id" || $attribute[1] == "class") {
            if (in_array($attribute[2], $semanticTags)) {
                $tagNewName = $attribute[2];
                $hasAsemanticTag = true;
            }
        } else {

            if ($attribute[0][strlen($attribute[1])] == " ") {
                $newTag .= $attribute[1] . " =";
            } else {
                $newTag .= $attribute[1] . "=";
            }
            $equalPost = strpos($attribute[0], "=");
            if ($attribute[0][$equalPost + 1] == " ") {
                $newTag .= " " . "\"" . $attribute[2] . "\"";
            } else {
                $newTag .= "\"" . $attribute[2] . "\"";

            }
            $modifiedAttributes[] = $newTag;
        }

    }
    if ($hasAsemanticTag) {
        if (count($modifiedAttributes) != 0)
            return substr_replace($line, "<" . $tagNewName . " " . implode(" ", $modifiedAttributes) . ">", $startIndex);
        else
            return substr_replace($line, "<" . $tagNewName . ">", $startIndex);

    } else {
        return false;
    }
    //var_dump($attributes, $offsets);

}


function checkForClosedTagAndFormatIt($line)
{
    global $semanticTags;

    $startIndex = strpos($line, "</div>");
    if ($startIndex === false) {
        return false;
    }
    if (strpos($line, "<!--") === false) {
        return false;
    }
    foreach ($semanticTags as $semanticTag) {
        if (strpos($line, $semanticTag) !== false) {
            return substr_replace($line, "</" . $semanticTag . ">", $startIndex);
        }
    }

    return false;
}

foreach ($lines as $key => $line) {

    $lineMod = checkForOpenTagAndFormatIt($line);
    if ($lineMod !== false) {
        $lines[$key] = $lineMod;
    }

    $lineMod = checkForClosedTagAndFormatIt($line);
    if ($lineMod !== false) {
        $lines[$key] = $lineMod;
    }

}
foreach ($lines as $key => $line) {

    echo(rtrim($line));
    echo "\n";
}
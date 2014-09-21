<?php
$text = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$style = getTag($_GET['fontStyle']);

$hashedText = $text;
for ($i = 0; $i < strlen($hashedText); $i++) {
    if ($i % 2 == 0) {
        $hashedText[$i] = chr(ord($hashedText[$i]) + $hashValue);
    } else {
        $hashedText[$i] = chr(ord($hashedText[$i]) - $hashValue);

    }
}

function getTag($style) {
    switch ($style) {
        case "normal":
        case "italic":
            return "font-style:$style;";
        case "bold":
            return "font-weight:bold;";
        default: return "";
    }
}


echo "<p style=\"font-size:{$fontSize};{$style}\">{$hashedText}</p>";
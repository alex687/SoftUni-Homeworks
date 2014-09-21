<?php
$text = $_GET['text'];

preg_match_all('/[A-Za-z\d+_-]+@[\da-zA-Z\-]+[.\da-zA-z]+/', $text, $emails, PREG_OFFSET_CAPTURE);
//$blackList = array("*.bg", "*.com", "pesho@dir.tk");
$blackList = preg_split("/\s/", $_GET['blacklist'], -1, PREG_SPLIT_NO_EMPTY);
//
$matched = array_fill(0, count($emails[0]), false);

foreach ($blackList as $blackItem) {
    if ($blackItem[0] == '*') {
        foreach ($emails[0] as $key => $email) {
            if (checkForIfEndsWith($email[0], $blackItem)) {
                $matched[$key] = true;
            }
        }
    } else {
        foreach ($emails[0] as $key => $email) {
            if ($email[0] === $blackItem) {
                $matched[$key] = true;
            }
        }
    }
}
function checkForIfEndsWith($email, $blackItem)
{
    $blackItem = substr($blackItem, 1);
    $pos = strrpos($email, $blackItem);

    if ($pos !== false && $pos + strlen($blackItem) == strlen($email)){
        return true;
    }

    return false;
}

$newText = $text;
for ($i = 0; $i < count($matched); $i++) {
    if ($matched[$i]) {
        $newText = substr_replace($newText, str_repeat("*", strlen($emails[0][$i][0])), $emails[0][$i][1], strlen($emails[0][$i][0]));
    }
}

$newText = preg_replace_callback('/[A-Za-z\d+_-]+@[\da-zA-Z\-]+[.\da-zA-z]+/', function ($match) {
    return "<a href=\"mailto:{$match[0]}\">{$match[0]}</a>";
}, $newText);


echo "<p>".$newText."</p>";

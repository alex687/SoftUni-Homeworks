<?php
$text = $_GET['text'];
$key = $_GET['key'];
$regex = regexBuilder($key);
preg_match_all("/" . $regex. "(.{2,6})" . $regex. "/", $text, $matches);

echo(implode("",$matches[1]));


function regexBuilder($key)
{
    $regex = $key[0];
    for ($i = 1; $i < strlen($key) - 1; $i++) {
        if (is_numeric($key[$i])) {
            $regex .= '\d*';
        } else if (ctype_alpha($key[$i])) {
            if (ctype_upper($key[$i])) {
                $regex .= '[A-Z]*';
            } else {
                $regex .= '[a-z]*';
            }
        } else {
            $regex .= '\\'.$key[$i];
        }
    }
    $regex .= $key[strlen($key) - 1];

    return $regex;
}
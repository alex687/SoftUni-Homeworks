<?php
$list = preg_split("/\n/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
$maxSize = $_GET['maxSize'];


echo "<ul>";
foreach ($list as $sentence) {
    $sentenceTrimmed = trim($sentence);
    if (strlen($sentenceTrimmed) == 0)
        continue;
    if (strlen($sentenceTrimmed) > $maxSize) {
        echo "<li>" . htmlspecialchars(substr($sentenceTrimmed, 0, $maxSize)) . "..." . "</li>";
    } else {
        echo "<li>" . htmlspecialchars($sentenceTrimmed) . "</li>";
    }
}
echo "</ul>";

<?php
date_default_timezone_set("Europe/Sofia");
//mb_internal_encoding('UTF8');


$dateOne = new dateTime($_GET['dateOne']);
$dateTwo = new dateTime($_GET['dateTwo']);


$holidays = preg_split("/\s/", $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);
//$holidays = explode("\n", $_GET['holidays']);
$workDays = array();
while ($dateOne <= $dateTwo) {
    if ($dateOne->format("N") < 6 && !in_array($dateOne->format('d-m-Y'), $holidays)) {
        array_push($workDays, $dateOne->format('d-m-Y'));
    }

    $dateOne->add(new DateInterval('P1D'));
}
if (count($workDays) > 0) {
    echo "<ol>";
    foreach ($workDays as $workDay) {
        echo "<li>{$workDay}</li>";
    }
    echo "</ol>";
}
else{
    echo("<h2>No workdays</h2>");
}

<?php

function getSundaysInMonth(DateTime $date){
    $y = $date->format("Y");
    $m = $date->format("n");
    return new DatePeriod(
        new DateTime("first sunday of $y-$m"),
        DateInterval::createFromDateString('next sunday'),
        new DateTime("last day of $y-$m")
    );
}

$date = new DateTime("now");
foreach (getSundaysInMonth($date) as $wednesday) {
    echo $wednesday->format("jS F,o\n").'</br>';
}
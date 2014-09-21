<?php
date_default_timezone_set("Europe/Sofia");

$firstDate = new dateTime($_GET['dateOne']);
$secondDate = new dateTime($_GET['dateTwo']);

$startDate = min($firstDate, $secondDate);
$endDate = max($firstDate, $secondDate);

$thursdays = array();
while($startDate<= $endDate){
    if($startDate->format("N") == 4){
        array_push($thursdays,$startDate->format('d-m-Y'));
    }

    $startDate->add(new DateInterval('P1D'));
}

if(count($thursdays) >0){
    echo"<ol>";
    foreach($thursdays as $thursday){
        echo"<li>$thursday</li>";
    }
    echo"</ol>";
}
else{
    echo("<h2>No Thursdays</h2>");
}
?>
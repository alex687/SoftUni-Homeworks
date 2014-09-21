<?php
$date = new DateTime("now");
$newYear = new DateTime('2015-01-01');


$interval = $date->diff($newYear);

$hours = (int)$interval->format('%h');
$minutes = (int)$interval->format('%i');
$seconds = (int)$interval->format('%s');

$daysTotal = (int)$interval->format('%a');
$hoursTotal = $daysTotal * 24 + $hours;
$minutesTotal = $hoursTotal * 60 + $minutes;
$secondsTotal = $minutesTotal * 60 + $seconds;
?>
<pre>
<?php
echo "Hours until new year : " . $hoursTotal . PHP_EOL;
echo "Minutes until new year : " . $minutesTotal . PHP_EOL;
echo "Seconds until new year : " . $secondsTotal . PHP_EOL;
echo "Days:Hours:Minutes:Seconds : " . $interval->format("%a:%h:%i:%s") . PHP_EOL;
?>
    </pre>
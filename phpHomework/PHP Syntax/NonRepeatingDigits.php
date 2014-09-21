<pre>
<?php
function nonRepeatingDigits($n)
{
    if ($n < 100) {
        return array();
    }

    $digits = array();
    for ($firDig = 1; $firDig < 10; $firDig++) {
        for ($secDig = 0; $secDig < 10; $secDig++) {
            if ($secDig == $firDig) {
                continue;
            }
            for ($thrDig = 0; $thrDig < 10; $thrDig++) {
                if ($secDig == $thrDig) {
                    continue;
                }
                $digit = (int)($firDig . $secDig . $thrDig);
                if ($digit > (int)$n) {
                    return $digits;
                }

                array_push($digits, $digit);
            }
        }
    }

    return $digits;
}

$digits = nonRepeatingDigits(1234);
if (!empty($digits)) {
    echo implode(", ", $digits);
}
echo PHP_EOL;

$digits = nonRepeatingDigits(145);
if (!empty($digits)) {
    echo implode(", ", $digits);
}
echo PHP_EOL;


$digits = nonRepeatingDigits(15);
if (!empty($digits)) {
    echo implode(", ", $digits);
} else {
    echo "no";
}
echo PHP_EOL;


$digits = nonRepeatingDigits(247);
if (!empty($digits)) {
    echo implode(", ", $digits);
}
?>
    </pre>
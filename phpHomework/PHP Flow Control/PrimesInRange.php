<?php
function isPrime($number)
{
    for ($i = 2; $i <= sqrt($number); $i++) {
        if ($number % $i == 0) {
            return false;
        }
    }
    return true;
}

function checkPrimeRange($start, $end)
{
    for ($i = $start; $i <= $end; $i++) {
        if (isPrime($i)) {
            echo "<strong>{$i}, </strong>";
        } else {
            echo $i.", ";
        }
    }
}

?>

<!DOCTYPE html>
<html>
<head>
    <title>Primes in range</title>
</head>
<body>
<form action="" method="post">
    <label for="cars">Start</label>
    <input type="number" name="start" id="start"/>
    <label for="end">End</label>
    <input type="number" name="end" id="end"/>
    <input type="submit" value="Show Results"/>
</form>
<?php
if (isset($_POST['start']) && isset($_POST['end']) &&
    is_numeric($_POST['start']) && is_numeric($_POST['end'])
) {
    checkPrimeRange($_POST['start'], $_POST['end']);
}
?>
</body>
</html>
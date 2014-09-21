<?php
if (!empty($_POST['numbers'])) {
    $numbers = preg_split("/[, ]+/", $_POST['numbers'], -1, PREG_SPLIT_NO_EMPTY);
    for ($i = 0; $i < count($numbers); $i++) {
        $number = (string)$numbers[$i];
        if (filter_var($number, FILTER_VALIDATE_INT)) {
            $digitsSum = 0;
            for ($j = 0; $j < strlen($number); $j++) {
                $digitsSum += $number[$j];
            }
            $numbers[$i] = array($number, $digitsSum);
        } else {
            $numbers[$i] = array($number, false);
        }
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Sum of digits</title>
</head>
<body>
<form action="" method="post">
    <label for="numbers">Input string</label>
    <input type="text" name="numbers" id="numbers"/>
    <input type="submit" value="Show costs"/>
</form>
<?php if (!empty($numbers)): ?>
    <table border="1">
        <tbody>
        <?php
        foreach ($numbers as $number) {
            if ($number[1] !== false) {
                echo "<tr><td>{$number[0]}</td><td>{$number[1]}</td></tr>";
            } else {
                echo "<tr><td>{$number[0]}</td><td>I cannot sum that</td></tr>";
            }
        }
        ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>
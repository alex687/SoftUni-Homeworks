<!DOCTYPE html>
<html>
<head>
    <title>SquareRootSum</title>
</head>
<body>

<table border="1">
    <tr>
        <th><strong>Number</strong></th>
        <th><strong>Square</strong></th>
    </tr>
    <?php
    $sumSquares = 0;
    for ($i = 0; $i <= 100; $i += 2):
        $square = round(sqrt($i), 2);
        $sumSquares += $square;
        ?>
        <tr>
            <td><?= $i ?></td>
            <td><?= $square ?></td>
        </tr>
    <?php
    endfor;
    ?>
    <tr><td><strong>Total:</strong></td> <td><?=$sumSquares?></td></tr>
</table>
</body>
</html>

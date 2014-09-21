<!DOCTYPE html>
<html>
<head>
    <title>Show Annual Expenses</title>
</head>
<body>
<form action="" method="post">
    <label for="cars">Enter number of years</label>
    <input type="number" name="years" id="years"/>
    <input type="submit" value="Show costs"/>
</form>
<?php if (!empty($_POST['years'])): ?>
    <table border="1">
        <thead>
        <tr>
            <th>Year</th>
            <th>January</th>
            <th>February</th>
            <th>March</th>
            <th>April</th>
            <th>May</th>
            <th>June</th>
            <th>July</th>
            <th>August</th>
            <th>September</th>
            <th>October</th>
            <th>November</th>
            <th>December</th>
            <th>Total:</th>
        </tr>
        </thead>
        <tbody>
        <?php for ($i = 2014;
                   $i > 2014 - $_POST['years'];
                   $i--): ?>
            <tr>
                <td><?=$i?></td>
                <?php
                $total = 0;
                for ($j = 1; $j <= 12; $j++):
                    $cost = rand(0, 999);
                    $total += $cost;
                    ?>
                    <td><?= $cost ?></td>
                <?php
                endfor;?>
                <td><?= $total ?></td>
            </tr>
        <?php
        endfor;
        ?>
        </tbody>
    </table>
<?php endif; ?>
</body>
</html>
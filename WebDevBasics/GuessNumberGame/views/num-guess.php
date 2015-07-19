<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<?php
if (isset($_POST['num'])) {
    if ($_SESSION['number'] > $_POST['num']) {
        echo "Up";
    }

    if ($_SESSION['number'] > $_POST['num']) {
        echo "Down";
    }

    if ($_SESSION['number'] == $_POST['num']) {
        echo "You won";
    }
}
?>

<form method="post">
    <input type="number" name="num" placeholder="Number between 1 and 100">
    <input type="submit" value="Submit button">
</form>
</body>
</html>
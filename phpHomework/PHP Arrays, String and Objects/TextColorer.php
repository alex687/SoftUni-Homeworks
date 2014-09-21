<!DOCTYPE html>
<html>
<head>
    <title>Text Colored</title>
    <style>
        .red {
            color: red;
        }

        .blue {
            color: blue;
        }
    </style>
</head>
<body>
<form action="TextColorer.php" method="POST">
    <textarea name="text">What a wonderful world!</textarea>
    <input type="submit" value="Submit"/>

    <p>
        <?php
        if (!empty($_POST['text'])) {
            $characters = preg_split('/\s*/', $_POST['text'], -1, PREG_SPLIT_NO_EMPTY);

            foreach ($characters as $character) {
                if (ord($character) % 2 == 0) {
                    echo "<span class='red'>$character</span> ";
                } else {
                    echo "<span class='blue'>$character</span> ";
                }
            }
        }
        ?>
    </p>
</form>
</body>
</html>

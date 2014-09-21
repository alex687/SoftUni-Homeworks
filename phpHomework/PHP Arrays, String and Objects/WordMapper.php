<!DOCTYPE html>
<html>
<head>
    <title>Word Mapper</title>
</head>
<body>
<form action="WordMapper.php" method="POST">
    <textarea name="text">The quick brows fox.!!! jumped over..// the lazy dog.!</textarea>
    <input type="submit" value="Submit"/>
    <?php
    if (!empty($_POST['text'])):
        $words = preg_split('/[^\w+]/', $_POST['text'], -1, PREG_SPLIT_NO_EMPTY);

        $wordOccurs = array();
        foreach ($words as $key => $word) {
            $wordCi = strtolower($word);
            if (isset($wordOccurs[$wordCi])) {
                $wordOccurs[$wordCi]++;
            } else {
                $wordOccurs[$wordCi] = 1;
            }
        }
        arsort($wordOccurs);
        echo '<table>';
        foreach ($wordOccurs as $word => $frequency){
            echo '<tr>';
            echo"<td>$word</td><td>$frequency</td>";
            echo '</tr>';
        }
        echo '</table>';

    endif;
    ?>
</form>
</body>
</html>

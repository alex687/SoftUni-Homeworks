<!DOCTYPE html>
<html>
<head>
    <title>Problem 2.	Most Frequent Tag</title>
</head>
<body>
<form action="MostFrequentTag.php" method="POST">
    <input type="text" name="tags"/>
    <input type="submit" value="Submit"/>
    <?php
    if (isset($_POST['tags'])):
        $tags = explode(', ', $_POST['tags']);

        $tagsFQ = array();
        foreach ($tags as $key => $tag) {
            if (isset($tagsFQ[$tag])) {
                $tagsFQ[$tag]++;
            } else {
                $tagsFQ[$tag] = 1;
            }
        }
        arsort($tagsFQ);

        foreach ($tagsFQ as $tag => $frequency):
            ?>
            <p><?= $tag ?>:<?= $frequency ?></p>
        <?php
        endforeach;
        $mostFrequent = current( array_keys($tagsFQ));
        ?>
        <p>Most Frequent Tag is: <?=$mostFrequent?></p>
    <?php
    endif;
    ?>
</form>
</body>
</html>

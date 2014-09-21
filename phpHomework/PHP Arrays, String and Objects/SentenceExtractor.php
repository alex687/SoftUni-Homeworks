<!DOCTYPE html>
<html>
<head>
    <title>Sentence Extractor</title>
</head>
<body>
<form action="SentenceExtractor.php" method="POST">
    <textarea name="text">This is my cat! And this is my dog. We happily live in Paris – the most beautiful city in the
        world! Isn’t it great? Well it is :)
    </textarea>
    <input type="text" name="word" value="is">
    <input type="submit" value="Submit"/>

    <p>
        <?php
        if (!empty($_POST['text']) && !empty($_POST['word'])) {
            $word = $_POST['word'];

            $sentences = preg_split('/(?<=[.?!])/', $_POST['text'], -1, PREG_SPLIT_NO_EMPTY);
            foreach ($sentences as $sentence) {
                if (strpos('.?!', $sentence[strlen($sentence) - 1]) !== false) {
                    $words = preg_split('/[^\w]+/', $sentence, -1, PREG_SPLIT_NO_EMPTY);
                    if (in_array($word, $words)) {
                        echo "<p>$sentence</p>";
                    }
                }
            }
        }
        ?>
    </p>
</form>
</body>
</html>

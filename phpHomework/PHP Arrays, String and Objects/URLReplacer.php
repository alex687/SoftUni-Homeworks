<?php
function changeATag($match)
{
    return "[URL=".$match[1]."]".$match[2]."[/URL]";
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>URL replace</title>
</head>
<body>
<form action="URLReplacer.php" method="POST">
    <textarea name="text"><p>Come and visit <a href="http://softuni.bg">the Software University</a> to master the art of
            programming. You can always check our <a href="www.softuni.bg/forum">forum</a> if you have any questions.
        </p>
    </textarea>
    <input type="submit" value="Submit"/>

    <p>
        <?php
        if (!empty($_POST['text'])) {
            echo preg_replace_callback('/<a href="([^"]+)"\s*>(.+?(?=<\/a>))<\/a>/', 'changeATag', $_POST['text']);
        }
        ?>
    </p>
</form>
</body>
</html>

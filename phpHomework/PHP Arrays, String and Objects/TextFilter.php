<?php
if (!empty($_POST['text']) && !empty($_POST['banlist'])) {
    $banList = preg_split('/[, ]+/', $_POST['banlist'], -1, PREG_SPLIT_NO_EMPTY);

    function checkWordBanned($match)
    {
        $word = $match[0];
        global $banList;
        if (in_array($word, $banList)) {
            return str_repeat('*', strlen($word));
        } else {
            return $word;
        }
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Text Filter</title>
</head>
<body>
<form action="TextFilter.php" method="POST">
    <textarea name="text">It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the
        functionality. Therefore we owe it to them by calling the OS GNU/Linux!
        Sincerely, a Windows client
    </textarea>
    <input type="text" name="banlist" value="Linux, Windows">
    <input type="submit" value="Submit"/>

    <p>
        <?php
        if (!empty($_POST['text']) && !empty($_POST['banlist'])) {
            $newText = preg_replace_callback("/\w+'{0,1}\w+/", 'checkWordBanned', $_POST['text']);
            echo $newText;
        }
        ?>
    </p>
</form>
</body>
</html>

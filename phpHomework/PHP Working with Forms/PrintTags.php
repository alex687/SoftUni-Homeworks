<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
</head>
<body>
<form action="PrintTags.php" method="POST">
    <input type="text" name="tags"/>
    <input type="submit" value="Submit"/>
    <?php
    if(isset($_POST['tags'])):
        $tags = explode(', ', $_POST['tags']);
        foreach($tags as $key=>$tag):
    ?>
        <p><?=$key?>:<?=$tag?></p>
    <?php
        endforeach;
    endif;
    ?>
</form>
</body>
</html>

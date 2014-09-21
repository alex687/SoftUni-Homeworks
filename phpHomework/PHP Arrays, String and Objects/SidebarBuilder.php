<?php
function buildSidebar($header, $stringTags)
{
    $tags = preg_split('/[, ]+/', $stringTags, -1, PREG_SPLIT_NO_EMPTY);
    if (!empty($tags)) {
        echo "<sidebar>";
        echo "<h2>$header</h2>";
        echo "<ul>";
        foreach ($tags as $tag) {
            echo "<li>$tag</li>";
        }
        echo "</ul>";
        echo "</sidebar>";
    }
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>Sidebar Builder</title>
</head>
<body>
<form action="SidebarBuilder.php" method="POST">
    <label for="categories">Categories</label>
    <input type="text" name="categories" id="categories">
    <label for="tags">Tags</label>
    <input type="text" name="tags" id="tags">
    <label for="months">Months</label>
    <input type="text" name="months" id="months">
    <input type="submit" value="Submit"/>

    <p>
        <?php
        if (isset($_POST['categories'])) {
            buildSidebar("Categories", $_POST['categories']);
            buildSidebar("Tags", $_POST['tags']);
            buildSidebar("Months", $_POST['months']);
        }
        ?>
    </p>
</form>
</body>
</html>

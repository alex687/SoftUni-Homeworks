<!DOCTYPE html>
<?php
$continents = array(
    "Europe" => array('Croatia', 'Germany', 'England', 'Bulgaria', 'Latvia', 'Russia', 'Ukraine', 'Italy'),
    "Asia" => array('Vietnam', 'China', 'India'), "North America" => array('USA', 'Canada'),
    "South America" => array('Brasilia', 'Argentina'), "Australia" => array('Australia'),
    "Africa" => array('Nigeria', 'Egypt')
);

?>
<html>
<head>
    <title>Combo Box</title>
    <script>
        function getContinent() {
            document.getElementById("continents").parentNode.submit();
        }
    </script>
    <style>
        select {
            width: 160px;
        }
    </style>
</head>
<body onload="onlyOnLoad()">
<input type="hidden" id="selected" name="selectedVal" value="<?= @$_POST['continents'] ?>"/>

<form action="ComboBox.php" method="post">
    <select name="continent" id="continents" onchange="getContinent()">
        <option value="empty" id="null" <?php if (!isset($_POST['continent'])) echo "selected"; ?> disabled></option>
        <?php
        foreach (array_keys($continents) as $continent):
            ?>
            <option
                value="<?= $continent ?>" <?php if (isset($_POST['continent']) && $continent == $_POST['continent']) echo "selected"; ?>><?= $continent ?></option>
        <?php endforeach; ?>
    </select>
    <?php
    if (isset($_POST['continent'])) :
        ?>
        <select name="countries" id="countries" onchange="getContinent()">
            <?php


            $_SESSION['cont'] = $_POST['continent'];
            $continent = $_POST['continent'];

            if (isset($continents[$continent])) {
                foreach ($continents[$continent] as $country):
                    ?>
                    <option value="<?= $country ?>"><?= $country ?></option>

                <?php
                endforeach;
            }
            ?>

        </select>
    <?php
    endif;
    ?>
</form>
<a href="ComboBox.php">
    <button>Reset</button>
</a>
</body>
</html>
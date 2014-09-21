<html>
<head></head>
<body>
    <form action="GetFormData.php" method="post">
        <input type="text" name="name"><br>
        <input type="text" name="age"><br>
        <input type="radio" name="sex" value="male">Male<br>
        <input type="radio" name="sex" value="female">Female
        <input type="submit">
    </form>
<?php
    if(isset($_POST['name']) && isset($_POST['age']) && isset($_POST['sex'])){
        echo("My name is ". $_POST['name']. ".I am ". $_POST['age']. " years old. I am ". $_POST['sex']);
    }
?>
</body>
</html>
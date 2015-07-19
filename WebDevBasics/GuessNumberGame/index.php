<?php
session_start();

if (empty($_SESSION['number'])) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $_SESSION['number'] = rand(1, 100);
        $_SESSION['name'] = $_POST['name'];
    } else {
        include "views/reg.php";
    }
}

if (isset($_SESSION['number'])) {
    include "views/num-guess.php";
}
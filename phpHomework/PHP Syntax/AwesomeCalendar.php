<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            text-align: center;
            font-family: arial, sans-serif;
        }
        .calendar {
            width: 800px;
            margin: 0 auto;
        }
        table {
            display: inline-block;
            vertical-align: top;
            margin-bottom: 10px;
            margin-right: 10px;
        }

        td.table-headers {
            border-top: 1px solid black;
            border-bottom: 1px solid black;

        }

        td {
            width: 30px;
            height: 30px;
            text-align: center;
            font-size: 15px;
            box-sizing: border-box;
        }

        div.year-welcome-msg {
            text-align: center;
            font-size: 50px;
        }

        thead.month-text {
            font-size: 20px;
        }

        td.table-cells-weekends {
            color: red;
        }
    </style>
</head>
<body>

<?php
 require_once('Calendar.php');

$calendar = new Calendar(2014);
$calendar->draw();
?>

</body>
</html>
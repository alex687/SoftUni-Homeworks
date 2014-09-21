<!DOCTYPE html>
<?php
if(isset($_POST['firstNames']) && isset($_POST['secondNames']) && isset($_POST['emails']) &&
    isset($_POST['scores']) && isset($_POST['sortBy']) && isset($_POST['order'])) {

    class Student {
        public $firstName;
        public $secondName;
        public $email;
        public $score;

        function __construct($fname, $sname, $mail, $score) {
            $this->firstName = $fname;
            $this->secondName = $sname;
            $this->email = $mail;
            $this->score = $score;
        }
    }

    $allFirstNames = $_POST['firstNames'];
    $allSecondNames = $_POST['secondNames'];
    $allEmails = $_POST['emails'];
    $allScores = $_POST['scores'];

    $currentSortBy = $_POST['sortBy'];
    $currentSortType = $_POST['order'];

    $commonLength = count($allFirstNames);
    $accumulatedScore = 0;

    $allStudents = array();

    for($i = 0; $i < $commonLength ;$i++) {
        $newPerson = new Student($allFirstNames[$i], $allSecondNames[$i], $allEmails[$i], $allScores[$i]);
        $allStudents[] = $newPerson;
        $accumulatedScore += $allScores[$i];
    }

    function sortByFirstName($a, $b) {
        if($a->firstName < $b->firstName) {
            return -1;
        }
        else if($a->firstName > $b->firstName) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByLastName($a, $b) {
        if($a->secondName < $b->secondName) {
            return -1;
        }
        else if($a->secondName > $b->secondName) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByEmail($a, $b) {
        if($a->email < $b->email) {
            return -1;
        }
        else if($a->email > $b->email) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByScore($a, $b) {
        return $a->score - $b->score;
    }

    function sortByFirstNameDesc($b, $a) {
        if($a->firstName < $b->firstName) {
            return -1;
        }
        else if($a->firstName > $b->firstName) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByLastNameDesc($b, $a) {
        if($a->secondName < $b->secondName) {
            return -1;
        }
        else if($a->secondName > $b->secondName) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByEmailDesc($b, $a) {
        if($a->email < $b->email) {
            return -1;
        }
        else if($a->email > $b->email) {
            return 1;
        }
        else {
            return 0;
        }
    }

    function sortByScoreDesc($b, $a) {
        return $a->score - $b->score;
    }


    if($currentSortBy == 'fname') {
        if($currentSortType == 'ascend') {
            usort($allStudents, 'sortByFirstName');
        }
        else {
            usort($allStudents, 'sortByFirstNameDesc');
        }
    }
    else if($currentSortBy == 'sname') {
        if($currentSortType == 'ascend') {
            usort($allStudents, 'sortByLastName');
        }
        else {
            usort($allStudents, 'sortByLastNameDesc');
        }
    }
    else if($currentSortBy == 'email') {
        if($currentSortType == 'ascend') {
            usort($allStudents, 'sortByEmail');
        }
        else {
            usort($allStudents, 'sortByEmailDesc');
        }
    }
    else if($currentSortBy == 'examScore') {
        if($currentSortType == 'ascend') {
            usort($allStudents, 'sortByScore');
        }
        else {
            usort($allStudents, 'sortByScoreDesc');
        }
    }

    $tableData = '<table id="result-table"><thead><tr><th>First Name</th><th>Second Name</th>' .
        '<th>Email</th><th>Exam Score</th></tr></thead><tbody>';

    for($i = 0; $i < count($allStudents) ;$i++) {
        $tableData .= "<tr><td> {$allStudents[$i]->firstName} </td>" .
            "<td> {$allStudents[$i]->secondName} </td>" .
            "<td> {$allStudents[$i]->email} </td>" .
            "<td> {$allStudents[$i]->score} </td></tr>";
    }
    $average = number_format($accumulatedScore / count($allStudents), 2);
    $tableData .= '<tr><td colspan="3" style="font-weight: bold">Average score:</td>' .
        "<td>{$average}</td></tr>";
    $tableData .= '</tbody></table>';
}

?>
<html>
<head>
    <title>Student Sorting</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        var idCounter = 0;
        var parent = document.getElementById("parent-tbody-table");
        function addPerson() {
            var myNewRow = document.createElement("tr");
            myNewRow.setAttribute("id", "row" + idCounter);
            myNewRow.innerHTML = '<td><input type="text" name="firstNames[]" class="text-boxes" required/></td>' +
                '<td><input type="text" name="secondNames[]" class="text-boxes" required/></td>' +
                '<td><input type="email" name="emails[]" class="text-boxes" required/></td>' +
                '<td><input type="number" name="scores[]" class="text-boxes" min="0" max="400" required/>'
                + '<input type="button" name="removePerson" class="add-remove-buttons" value="-" onclick="removeButton(' +
                "row" + idCounter +')"/>' +
                '</td>';
            document.getElementById("parent-tbody-table").appendChild(myNewRow);
            idCounter++;
        }
        function removeButton(rowId) {
            $(document).ready(function() {
                $(rowId).remove();
            });
        }
    </script>
    <style>
        table#input-table {
            margin-bottom:10px;
        }
        table#input-table th {
            background: #3366CC;
        }
        th, td {
            width:260px;
            text-align: center;
        }
        input.text-boxes {
            width:260px;
            height: 30px;
            font-size:20px;
        }
        input[type="number"] {
            height: 30px;
            width:100px;
        }
        input.add-remove-buttons {
            width:30px;
            height: 30px;
            background: #003399;
            color:white;
        }
        table#result-table {
            border:1px solid black;
            border-collapse: collapse;
            margin-top:50px;
        }
        table#result-table td, table#result-table th {
            border:1px solid black;
            width:160px;
            text-align: left;
            padding:5px;
        }
        table#result-table th {
            background: #3366CC;
        }
    </style>
</head>
<body>
<form action="" method="post">
    <table border="1" id="input-table">
        <thead>
        <tr>
            <th>First name</th>
            <th>Second name</th>
            <th>Email</th>
            <th>Exam score</th>
        </tr>
        </thead>
        <tbody id="parent-tbody-table">

        </tbody>
    </table>
    <script>addPerson();</script>
    <input type="button" name="addNewPerson" value="+" class="add-remove-buttons" onclick="addPerson()"/>
    <label for="sort-by">Sort by:</label>
    <select name="sortBy" id="sort-by">
        <option value="fname">First name</option>
        <option value="sname">Second name</option>
        <option value="email">Email</option>
        <option value="examScore">Exam Score</option>
    </select>
    <label for="">Order</label>
    <select name="order" id="order">
        <option value="ascend">Ascending</option>
        <option value="descend">Descending</option>
    </select>
    <input type="submit" name="submitForm" id="submit" value="Submit"/>
</form>
<div id="result">
    <?php
    if(isset($tableData)) {
        echo $tableData;
    }
    ?>
</div>
</body>
</html>
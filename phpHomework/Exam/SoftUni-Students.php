<?php
class Student  {
    public $name;
    public $email;
    public $type;
    public $result;
    public $id;

    function __construct($name, $email, $type, $result, $id){
        $this->name=$name;
        $this->email=$email;
        $this->result=$result;
        $this->type= $type;
        $this->id = $id;
    }
}

class CreateStudents{
    private $id=1;
    public function createStudent($name, $email, $type, $result){
        $student = new Student($name, $email, $type, $result, $this->id);
        $this->id++;
        return $student;
    }

    public function createStudentUsingData($data){
        //$name = $data[0];
        $student = new Student(trim($data[0]), trim($data[1]), trim($data[2]), (int)(trim($data[3])), $this->id);
        $this->id++;
        return $student;
    }
}

$text = preg_split("/\n+/", htmlspecialchars($_GET['students']), -1, PREG_SPLIT_NO_EMPTY);
//var_dump($text);
//var_dump($text);
$students = array();
$createStudent = new CreateStudents();
foreach($text as $studentInputs){
    $studentData =  preg_split("/,+/", $studentInputs, -1, PREG_SPLIT_NO_EMPTY);
    //  var_dump($studentData);
    $students[]= $createStudent->createStudentUsingData($studentData);
}

$column = $_GET['column'];
$order = $_GET['order'];

if($column === "id" && $order=="ascending"){
    function compare ( Student $a, Student $b){
        return $a->id - $b->id;
    }
}

if($column === "id" && $order=="descending"){
    function compare ( Student $a, Student $b){
        return ($a->id - $b->id)* -1;
    }
}


if($column === "username" && $order=="ascending"){
    function compare (Student $a , Student $b){
        if(strcmp($a->name, $b->name) !==0){
            return strcmp($a->name, $b->name);
        }

       return $a->id - $b->id;
    }
}

if($column === "username" && $order=="descending"){
    function compare (Student $a , Student $b){
        if(strcmp($a->name, $b->name) !==0){
            return strcmp($a->name, $b->name)*-1;
      }
        return ($a->id - $b->id)* -1;
    }
}


if($column === "result" && $order=="descending"){
    function compare (Student $a , Student $b){
        if($a->result > $b->result)
            return -1;
        if($a->result < $b->result)
            return 1;
        return ($a->id - $b->id)* -1;
    }
}

if($column === "result" && $order=="ascending"){
    function compare (Student $a , Student $b){
        if($a->result > $b->result)
            return 1;
        if($a->result < $b->result)
            return -1;
        return ($a->id - $b->id)* 1;
    }
}

usort($students, "compare");

//var_dump($students);;
echo "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";
foreach($students as $student){
    echo "<tr>";

    echo "<td>";
    echo  ($student->id);
    echo "</td>";


    echo "<td>";
    echo ($student->name);
    echo "</td>";


    echo "<td>";
    echo ($student->email);
    echo "</td>";


    echo "<td>";
    echo ($student->type);
    echo "</td>";



    echo "<td>";
    echo ($student->result);

    echo "</td>";

    echo "</tr>";
}
echo "</table>";
<?php
class Person
{
    private $name;
    private $phoneNumber;
    private $age;
    private $address;

    function __construct($name, $phoneNumber, $age, $address)
    {
        $this->validate($phoneNumber, $age);

        $this->name = $name;
        $this->phoneNumber = $phoneNumber;
        $this->age = $age;
        $this->address = $address;
    }

    private function validate($phoneNumber, $age)
    {
        if (!$this->validateNumber($phoneNumber)) {
            throw new InvalidArgumentException("Invalid phone number");
        }

        if (!$this->validateAge($age)) {
            throw new InvalidArgumentException("Invalid age");
        }

    }

    private function validateNumber($phone)
    {
       return true;
    }

    private function validateAge($age)
    {

        return is_numeric($age);
    }

    /**
     * @return mixed
     */
    public function getAddress()
    {
        return $this->address;
    }

    /**
     * @return mixed
     */
    public function getAge()
    {
        return $this->age;
    }

    /**
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @return mixed
     */
    public function getPhoneNumber()
    {
        return $this->phoneNumber;
    }

    public function generateTable(){
        $table = new GenerateTable();
        $table->addRow();
        $table->addCell("Name", 0);
        $table->addCell($this->getName(), 0);

        $table->addRow();
        $table->addCell("Phone Number", 1);
        $table->addCell($this->getPhoneNumber(), 1);

        $table->addRow();
        $table->addCell("Age", 2);
        $table->addCell($this->getAge(), 2);

        $table->addRow();
        $table->addCell("Address", 3);
        $table->addCell($this->getAddress(), 3);

        echo $table->make();
    }
}


class GenerateTable
{
    private $table = array();

    public function addRow()
    {
        array_push($this->table, array());
    }

    public function addCell($data, $row)
    {
        if ($row > (count($this->table) - 1)) {
            return false;
        }

        array_push($this->table[$row], $data);
    }

    public function make(){
        $code = "<table>";
        for($row = 0; $row< count($this->table) ; $row++){
            $code .= "<tr>";
            for($cell = 0; $cell< count($this->table[$row]); $cell++){
                $code .="<td>".$this->table[$row][$cell]."</td>";
            }
            $code .="</tr>";
        }
        $code .="</table>";

        return $code;
    }
}

$person = new Person("Gosho", "123-456-7899", "24", "Hadji Dimitar");
$person->generateTable();

echo "</br>";
$person = new Person("Pesho", "0884-888-888", "67", "Suhata Reka");
$person->generateTable();
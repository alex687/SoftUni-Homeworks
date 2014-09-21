<?php
$text = $_GET['text'];
$lineLength = $_GET['lineLength'];

$matrix = array(array());
$matrix[0] = array_fill(0, $lineLength , " ");


$textLength = strlen($text) ;
$matrixIndex = 0;
$row = 0;
for ($i = 0; $i < $textLength; $i++) {
    if ($matrixIndex >= $lineLength) {
        $matrixIndex = 0;
        $row++;
        $matrix[] = array_fill(0, $lineLength, " ");
    }
    $matrix[$row][$matrixIndex] = $text[$i];
    $matrixIndex++;

}

for ($i = count($matrix)-1; $i >=0; $i--) {
    for ($j = 0; $j < count($matrix[$i]); $j++) {
       if($matrix[$i][$j] !== " "){
           $k = $i+1;
           $char = $matrix[$i][$j];
          while(@$matrix[$k][$j] === " "){
            $matrix[$k-1][$j] = " ";
            $matrix[$k][$j] = $char;
              $k++;
          }
       }
    }
}


echo "<table>";
for ($i = 0; $i < count($matrix); $i++) {
    echo "<tr>";
    for ($j = 0; $j < count($matrix[$i]); $j++) {
        echo "<td>".htmlspecialchars($matrix[$i][$j]) . "</td>";
    }
    echo "</tr>";
}
echo "<table>";
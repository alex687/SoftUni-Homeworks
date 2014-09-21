<?php
$decode = (array)json_decode($_GET['mainWord']);
$word = array_values($decode)[0];
preg_match('/[\d]+/', array_keys($decode)[0], $rowArray);
$row = $rowArray    [0];
//var_dump($rowArray);
$playWords = (array)json_decode($_GET['words']);

$maxWord = 'net';
$yPos = 0;
$xPos = 0;
for ($j = 0; $j < count($playWords); $j++) {
    for ($i = 0; $i < strlen($word); $i++) {
        $charPos = strpos($playWords[$j], $word[$i]);
        if ($charPos !== false) {
            if ($row - ($charPos + 1) >= 0 && (strlen($word) - $row) - (strlen($playWords[$j]) - $charPos - 1) >= 0) {
                if (strlen($maxWord) < strlen($playWords[$j])) {
                    $maxWord = $playWords[$j];
                    $yPos = $row - ($charPos);
                    $xPos = $i + 1;
                }
            }
        }
    }
}
//var_dump($yPos);
function tableBuilder($maxWord, $xPos, $yPos)
{
    global $row, $word;
    $maxWordCounter = 0;
    echo "<table>";
    for ($i = 1; $i <= strlen($word); $i++) {
        echo "<tr>";
        for ($j = 1; $j <= strlen($word); $j++) {
            echo "<td>";
            $toEcho = '';
            if ($i == $row) {
                $toEcho = $word[$j - 1];
            }
             if ($i >= $yPos && $i <= (strlen($maxWord)+($yPos-1)) && $j == $xPos) {
                $toEcho= $maxWord[$maxWordCounter];
                    $maxWordCounter++;
                }
            echo $toEcho;
            echo "</td>";
        }
        echo "</tr>";
    }
    echo "</table>";

}

tableBuilder($maxWord, $xPos, $yPos);


function getACIIsum($word)
{
    $sum = 0;
    for ($i = 0; $i < strlen($word); $i++) {
        $sum += ord($word[$i]);
    }
    return $sum;
}

function wordsSum($words, $maxWord)
{
    $sumWord = array();
    $wordsRepeat = array();

    foreach ($words as $word) {
        if ($maxWord == $word) continue;
        if (empty($sumWord[$word])) {
            $sumWord[$word] = getACIIsum($word);
        }

        if (empty($wordsRepeat[$word])) {
            $wordsRepeat[$word] = 1;
        } else {
            $wordsRepeat[$word]++;
        }
    }

    foreach ($wordsRepeat as $word => $repeat) {
        $sumWord[$word] *= $repeat;
    }

    return $sumWord;
}
$wordsSum = wordsSum($playWords, $maxWord);
ksort($wordsSum);
echo json_encode($wordsSum,JSON_HEX_QUOT | JSON_HEX_TAG);


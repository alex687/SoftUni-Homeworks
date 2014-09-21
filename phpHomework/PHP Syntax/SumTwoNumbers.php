<?php
function sum($firstNumber, $secondNumber)
{
    return number_format((float)$firstNumber + $secondNumber, 2, '.', '');
}

echo '$firstNumber + $secondNumber = 5 + 2 = ' . sum(5, 2);
echo ' $firstNumber + $secondNumber = 1234.5678 + 333 = ' . sum(1234.5678, 333);
echo ' $firstNumber + $secondNumber = 1.567808 + 0.356 = ' . sum(1.567808, 0.356);
<?php
class String
{
    public static function checkPalindrome($string)
    {
        $len = strlen($string);
        for ($i = 0; $i < $len; $i++) {
            if ($string[$i] != $string[$len - 1 - $i]) {
                return $string." Is not a palindrome  !";
            }
        }

        return $string." Is a palindrome  !";
    }

    public static function reverse($reverseStr)
    {
        return strrev($reverseStr);
    }

    public static function split($split)
    {
        preg_match_all("/\w/", $split, $split);
        return implode(" ", $split[0]);
    }

    public static function hash($forHashing)
    {
        return crypt($forHashing);
    }

    public static function shuffle($string)
    {
        return str_shuffle($string);
    }
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>Sum of digits</title>
</head>
<body>
<form action="" method="post">
    <label for="string">Input string</label>
    <input type="text" name="string" id="string"/>
    <input type="radio" name="option" value="1">Check Palindrome
    <input type="radio" name="option" value="2">Reverse String
    <input type="radio" name="option" value="3">Split
    <input type="radio" name="option" value="4">Hash String
    <input type="radio" name="option" value="5">Shuffle String
    <input type="submit" value="Submit"/>
</form>
<?php
if(!empty($_POST['string']) && !empty($_POST['option']) ){
    $functions= array( 'checkPalindrome', 'reverse', 'split', 'hash', 'shuffle');
    echo String::$functions[$_POST['option']-1]((string)$_POST['string']);
}
 ?>
</body>
</html>
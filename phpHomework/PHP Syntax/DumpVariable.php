<?php
function dump($variable)
{
    if (is_numeric($variable)) {
        var_dump($variable);
    }
    else{
        echo gettype($variable).PHP_EOL;
    }
}

dump("hello");
dump(15);
dump(1.234);
dump(array(12, 234));
dump((object)[2, 3]);


function Solve(input) {
    input = input;
    function checkForI(width, height, i, j) {
        var count = 0;
        //console.log(input);
        for (var k = i; k < height; k++) {
            if (input[k][j] == 'o') {
                count++;
            }
            if(input[k][j]=='-'){
                break;
            }
            if (count == 4) {
                return true;
            }
        }

        return false;
    }

    function checkForO(width, height, i, j) {
        if (i + 1 < height && j + 1 < width) {
            if (input[i + 1][j] == 'o'
                && input[i][j + 1] == 'o'
                && input[i + 1][j + 1] == 'o')
                return true;
        }
        return false;
    }

    function checkForT(width, height, i, j) {
        if (j + 2 < width && i + 1 < height) {
            if (input[i + 1][j + 1] == 'o' && input[i][j + 1] == 'o' && input[i][j + 2] == 'o') {
                return true;
            }
        }
        return false;
    }

    function checkForS(width, height, i, j) {
       if (i - 1 > -1 && j + 2 < width) {
            if (input[i+1][j] == 'o' && input[i+1][j -1] == 'o' && input[i][j + 1] == 'o') {
                return true;
            }
        }
        return false;
    }

    function checkForZ(width, height, i, j) {
        if (i + 1 < height && j + 2 < width) {
            if (input[i+1][j ] == 'o' && input[i + 1][j + 1] == 'o' && input[i][j -1] == 'o') {
                return true;
            }
        }
        return false;
    }


    function checkForL(width, height, i, j) {
        if (i + 2 < height && j + 1 < width) {
            if (input[i + 1][j] == 'o' && input[i + 2][j] == 'o' && input[i + 2][j + 1] == 'o') {
                return true;
            }
        }
        return false;
    }


    function checkForJ(width, height, i, j) {
        if (i + 2 < height && j - 1 > -1) {
            if (input[i][j] == 'o' && input[i + 1][j] == 'o' && input[i + 2][j] == 'o' && input[i + 2][j - 1] == 'o') {
                return true;
            }
        }
        return false;
    }

    var width = input[0].length;
    var height = input.length;
    //console.log(width+"-"+height);

    var output = {"I" : 0, "L" : 0, "J" : 0, "O" : 0, "Z" : 0 , "S" : 0, "T" : 0}
    for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
            if (input[i][j] === 'o') {
                if (checkForI(width, height, i, j))
                  output["I"]++;

                if (checkForO(width, height, i, j))
                    output["O"]++;


                if (checkForT(width, height, i, j))
                    output["T"]++;


                if (checkForS(width, height, i, j))
                    output["S"]++;


                if (checkForZ(width, height, i, j))
                    output["Z"]++;



                if (checkForL(width, height, i, j))
                {output["L"]++;}



                if (checkForJ(width, height, i, j))
                { output["J"]++;}




                //if()
            }
        }
    }

    return JSON.stringify(output);
}

console.log(Solve(["--o--o-", "--oo-oo", "ooo-oo-", "-ooooo-", "---oo--"]));
console.log(Solve(["-oo", "ooo", "ooo"]));
console.log(Solve(["--oo",
                   "--oo",
                   "ooo-",
                   "-oo-"]));

console.log(Solve(["o--o",
                   "o--o",
                   "o--o",
                   "oooo"]));

console.log(Solve(["ooo",
                   "-o-"]));

console.log(Solve(["ooo",
                   "oo-"]));

console.log(Solve(["ooo",
                   "ooo"]));

console.log(Solve(["ooo",
                   "ooo",
                   "ooo",
                   "ooo",
                   "ooo",
                   "ooo",
                   "ooo",
                   "ooo",
                   "ooo"]));


console.log(Solve(["o-o",
                   "-o-",
                   "o-o",
                   "-o-",
                   "-oo",
                   "o--",
                   "-o-",
                   "-o-",
                   "ooo"]));
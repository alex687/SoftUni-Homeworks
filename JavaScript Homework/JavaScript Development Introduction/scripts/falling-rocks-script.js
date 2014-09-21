//canvas variables
var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");

// game variables
var startingScore = -10;
var continueAnimating = false;
var score;

// block variables
var blockWidth = 30;
var blockHeight = 15;
var blockSpeed = 10;
var block = {
    x: 0,
    y: canvas.height - blockHeight,
    width: blockWidth,
    height: blockHeight,
    blockSpeed: blockSpeed
}

// rock variables
var rockWidth = 20;
var rockHeight = 20;
var totalRocks = 10;
var rocks = [];
for (var i = 0; i < totalRocks; i++) {
    addRock();
}

//Load Images
var isBrickImageLoaded = false;
var brick = new Image();
brick.src = "images/SoftUni-Logo.png";
brick.onload = function () {
    isBrickImageLoaded = true;
};

var isBackgroundLoaded = false;
var background = new Image();
background.src = "https://softuni.bg/Content/design/3.jpg";
background.onload = function () {
    isBackgroundLoaded = true;
};

var lives = 1;

function addRock() {
    var rock = {
        width: rockWidth,
        height: rockHeight
    }
    resetRock(rock);
    rocks.push(rock);
}

// move the rock to a random position near the top-of-canvas
// assign the rock a random speed
function resetRock(rock) {
    rock.x = Math.random() * (canvas.width - rockWidth);
    rock.y = 15 + Math.random() * 30;
    rock.speed = 0.2 + Math.random() * 0.5;

    score++;
}


//left and right keypush event handlers
document.onkeydown = function (event) {
    if (event.keyCode == 39) {
        block.x += block.blockSpeed;
        if (block.x >= canvas.width - block.width) {
            continueAnimating = true;
            block.x = canvas.width - block.width;
        }
    } else if (event.keyCode == 37) {
        block.x -= block.blockSpeed;
        if (block.x <= 0) {
            block.x = 0;
        }
    }
}


function animate() {

    for (var i = 0; i < rocks.length; i++) {

        var rock = rocks[i];

        // test for rock-block collision
        if (isColliding(rock, block)) {
            continueAnimating = false;
            alert("Your score is :" + score);
            lives--;
            break;
        }

        // advance the rocks
        rock.y += rock.speed;

        // if the rock is below the canvas,
        if (rock.y > canvas.height) {
            resetRock(rock);
        }

    }


    // request another animation frame

    if (continueAnimating) {
        window.requestAnimationFrame(animate);
    }

    // redraw everything
    drawAll();

}

function isColliding(a, b) {
    return !(
        b.x > a.x + a.width || b.x + b.width < a.x || b.y > a.y + a.height || b.y + b.height < a.y);
}

function drawAll() {

    // clear the canvas
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    ctx.beginPath();

    if (isBackgroundLoaded) {
        ctx.drawImage(background, 0, 0, canvas.width, canvas.height);
    }
    else {
        ctx.fillStyle = "ivory";
        ctx.fillRect(0, 0, canvas.width, canvas.height);
    }
    // draw the block
    ctx.fillStyle = "skyblue";
    ctx.strokeStyle = "lightgray";
    ctx.rect(block.x, block.y, block.width, block.height);
    ctx.fill();

    // draw all rocks
    for (var i = 0; i < rocks.length; i++) {
        var rock = rocks[i];
        ctx.rect(rock.x, rock.y, rockWidth, rockHeight);
        if (isBrickImageLoaded) {
            ctx.drawImage(brick, rock.x, rock.y, rockWidth, rockHeight);
        }
    }
    // draw the score
    ctx.stroke();
    if (!isBrickImageLoaded) {
        ctx.fillStyle = "gray";
        ctx.fill();
    }

    ctx.font = "14px Times New Roman";
    ctx.fillStyle = "white";
    ctx.strokeStyle = "black";
    ctx.fillText("Score: " + score, 10, 15);
    ctx.fillText("Lives:" + lives, 200, 15);
}

// button to start the game
$("#start").click(function () {
    score = startingScore
    block.x = 0;
    lives = 1;
    for (var i = 0; i < rocks.length; i++) {
        resetRock(rocks[i]);
    }
    if (!continueAnimating) {
        continueAnimating = true;
        animate();
    }

});
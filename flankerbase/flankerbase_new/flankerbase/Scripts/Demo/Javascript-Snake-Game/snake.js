var snake;
var table;
var apple;
var isPaused = 0;

var initSnake = function(divId){

    createTable(divId);
    
    createSnake();
    
    generateNewApple();
    
    // bind keyboard event
    document.onkeydown = processKeydown;
    
    isPaused = 0;
    
    // start game
    window.setTimeout(processGame, 200);
}

var restartGame = function(){
    clearTable();
    createSnake();
    generateNewApple();
    if (isPaused == 1) {
        isPaused = 0;
        window.setTimeout(processGame, 200);
    }
}

var clearTable = function(){
    for (var i = 0; i < 20; i++) {
        for (var j = 0; j < 20; j++) {
            var cell = table.rows[i].cells[j];
            cell.className = '';
        }
    }
}

var createTable = function(divId){
    var snakeDiv = document.getElementById(divId);
    table = document.createElement('table');
    for (var i = 0; i < 20; i++) {
        var row = table.insertRow(i);
        for (var j = 0; j < 20; j++) {
            var col = row.insertCell(j);
        }
    }
    snakeDiv.appendChild(table);
}

var createSnake = function(){
    snake = {};
    snake.direction = 'R';
    snake.body = [{
        x: 10,
        y: 10
    }];
    snake.body[0].cell = table.rows[snake.body[0].x].cells[snake.body[0].y];
    snake.body[0].cell.className = 'snakeCell';
    snake.headPosition = 0;
}

// handle the key down event
var processKeydown = function(e){
    e = e || window.event;
    
    switch (e.keyCode) {
        case 37: // left
            if (snake.direction != 'R' && isPaused == 0) {
                snake.direction = 'L';
            }
            break;
        case 38: // up
            if (snake.direction != 'D' && isPaused == 0) {
                snake.direction = 'U';
            }
            break;
        case 39: // right
            if (snake.direction != 'L' && isPaused == 0) {
                snake.direction = 'R';
            }
            break;
        case 40: // down
            if (snake.direction != 'U' && isPaused == 0) {
                snake.direction = 'D';
            }
            break;
        case 32: // spacebar
            if (isPaused == 0) 
                isPaused = 1;
            else {
                isPaused = 0;
                processGame();
            }
            break;
        case 82: // R
            restartGame();
            break;
    }
}

// make a new apple on the table
var generateNewApple = function(){
    apple = getRandomUnusedCell();
    apple.cell.className = 'appleCell';
}

var getRandomUnusedCell = function(){
    var randomOne = {};
    while (!randomOne.x || !randomOne.y || !randomOne.cell || randomOne.cell.className != '') {
        randomOne.x = Math.floor(Math.random() * 20);
        randomOne.y = Math.floor(Math.random() * 20);
        randomOne.cell = table.rows[randomOne.x].cells[randomOne.y];
    }
    return randomOne;
}

// process game whem timeout
var processGame = function(){

    if (isPaused == 1) 
        return;
    
    var snakeHead = snake.body[snake.headPosition];
    var nextCell = {
        x: snakeHead.x,
        y: snakeHead.y
    };
    
    switch (snake.direction) {
        case 'R':
            nextCell.y++;
            break;
        case 'L':
            nextCell.y--;
            break;
        case 'U':
            nextCell.x--;
            break;
        case 'D':
            nextCell.x++;
            break;
    }
    
    if (isSnakeNotDead(nextCell)) {
        if (snakeEatApple(nextCell)) {
            addAppleToNewHead(nextCell);
            generateNewApple();
        }
        else {
            moveTailToNextCell(nextCell);
        }
        
        window.setTimeout(processGame, 200);
    }
    else 
        isPaused = 1;
}

// 
var isSnakeNotDead = function(nextCell){
    nextCell.x = nextCell.x >= 20 ? 0 : nextCell.x;
    nextCell.x = nextCell.x < 0 ? 19 : nextCell.x;
    nextCell.y = nextCell.y >= 20 ? 0 : nextCell.y;
    nextCell.y = nextCell.y < 0 ? 19 : nextCell.y;
    
    nextCell.cell = table.rows[nextCell.x].cells[nextCell.y];
    
    if (nextCell.cell.className == 'snakeCell') 
        return false;
    else 
        return true;
}

var snakeEatApple = function(nextCell){
    if (nextCell.x == apple.x && nextCell.y == apple.y) 
        return true;
    else 
        return false;
}

var moveTailToNextCell = function(nextCell){
    var tailPosition = snake.headPosition - 1;
    if (tailPosition < 0) 
        tailPosition = snake.body.length - 1;
    
    snake.body[tailPosition].cell.className = '';
    nextCell.cell.className = 'snakeCell';
    
    snake.body[tailPosition] = nextCell;
    snake.headPosition = tailPosition;
}

var addAppleToNewHead = function(nextCell){
    var newBody = new Array(snake.body.length + 1);
    newBody[0] = nextCell;
    for (var i = 0; i < snake.body.length; i++) {
        var j = i + snake.headPosition;
        if (j >= snake.body.length) 
            j -= snake.body.length;
        newBody[i + 1] = snake.body[j];
    }
    
    snake.body = newBody;
    snake.headPosition = 0;
    
    snake.body[0].cell.className = 'snakeCell';
}

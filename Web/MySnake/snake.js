var snake;
var table;
var apple;

var initSnake = function(divId) {

    // create snake table
    var snakeDiv = document.getElementById(divId);
    table = document.createElement('table');
    for (var i = 0; i < 20; i++) {
        var row = table.insertRow(i);
        for (var j = 0; j < 20; j++) {
            var col = row.insertCell(j);
        }
    }
    snakeDiv.appendChild(table);
    
    // create snake
    snake = {};
    snake.direction = 'R';
    snake.body = [{ x: 10, y: 10}];
    snake.body[0].cell = table.rows[snake.body[0].x].cells[snake.body[0].y];
    snake.body[0].cell.className = 'snakeCell';
    snake.headPosition = 0;
    
    // create apple
    generateNewApple();
    
    // bind keyboard event
    document.onkeydown = processKeydown;
    
    // start game
    window.setTimeout(processGame, 200);
}

var processKeydown = function(e) {
    e = e || window.event;
    
    switch (e.keyCode) {
        case 37: // left
            if (snake.direction != 'R') {
                snake.direction = 'L';
            }
            break;
        case 38: // up
            if (snake.direction != 'D') {
                snake.direction = 'U';
            }
            break;
        case 39: // right
            if (snake.direction != 'L') {
                snake.direction = 'R';
            }
            break;
        case 40: // down
            if (snake.direction != 'U') {
                snake.direction = 'D';
            }
            break;
    }
}

var generateNewApple = function() {
    apple = getRandomUnusedCell();
    apple.cell.className = 'appleCell';
}

var getRandomUnusedCell = function() {
    var randomOne = {};
    while (!randomOne.x || !randomOne.y || !randomOne.cell || randomOne.cell.className != '') {
        randomOne.x = Math.floor(Math.random() * 20);
        randomOne.y = Math.floor(Math.random() * 20);
        randomOne.cell = table.rows[randomOne.x].cells[randomOne.y];
    }
    return randomOne;
}

var processGame = function() {
    var snakeHead = snake.body[snake.headPosition];
    var nextCell = { x: snakeHead.x, y: snakeHead.y };
    
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
    
    if (snakeNotTouchTheWall(nextCell)) {
        nextCell.cell = table.rows[nextCell.x].cells[nextCell.y];
        
        if ( snakeEatApple(nextCell)) {
            addAppleToNewHead(nextCell);
            generateNewApple();
        }
        else {
            moveTailToNextCell(nextCell);
        }
        
        window.setTimeout(processGame, 200);
    }
}

var snakeNotTouchTheWall = function(nextCell) {
    if(nextCell.x >= 20 || nextCell.x < 0 || nextCell.y >= 20 || nextCell.y < 0) 
        return false;
    else
        return true;
}

var snakeEatApple = function(nextCell) {
    if (nextCell.x == apple.x && nextCell.y == apple.y) {
        return true;
    }
    else {
        return false;
    }
}

var moveTailToNextCell = function(nextCell) {
    var tailPosition = snake.headPosition - 1;
    if (tailPosition < 0)
        tailPosition = snake.body.length - 1;
    
    snake.body[tailPosition].cell.className = '';
    nextCell.cell.className = 'snakeCell';
    
    snake.body[tailPosition] = nextCell;
    snake.headPosition = tailPosition;
}

var addAppleToNewHead = function(nextCell) {
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
    
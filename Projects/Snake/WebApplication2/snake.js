// params: (div id to insert snake board,
//          width of game board (in snake segment units),
//          height of game board (in snake segment units),
//          id of element to insert score into (typically a span),
//          id of element to insert time into (typically a span),
//          id of element to insert high score into (typically a span)
//          prefix to the ids to append '-slow', '-medium', '-fast' for speed button/links ()) 
var Snake = function(divId, width, height, scoreId, timeId, highScoreId, resetId, speedPrefixId) {
    var div = document.getElementById(divId);
    var scoreField = document.getElementById(scoreId);
    var timeField = document.getElementById(timeId);
    var highScoreField = document.getElementById(highScoreId);
    var resetButton = document.getElementById(resetId);
    var table;
    
    var speeds = [{speed: 'slow', value: 200}, {speed: 'medium', value: 150}, {speed: 'fast', value: 100}];
    
    var delay; 
    var inGame;
    var snake;
    var apple;
    var score;
    var startTime;
    var gameDuration;
    
    // Init.            
    createTable();
    displayHighScore();
    // Set default delay to fast.
    delay = speeds[2].value;
    // Bind to speed buttons.
    for (var i = 0; i < speeds.length; i++) {
        with (speeds[i]) {
            document.getElementById(speedPrefixId + speed).onclick = function(e) {
                if (e)
                    e.preventDefault();
                else
                    window.event.returnValue = false;
                
                delay = value;
                
                if (!inGame) {
                    startGame();
                }
            }
        }
    }
    // Bind to reset button.
    resetButton.onclick = function(e) {
        if (e)
            e.preventDefault();
        else
            window.event.returnValue = false;
            
        setHighScore(0);
        displayHighScore();
    }
    // Bind to keyboard.
    document.onkeydown = function(e) {
        e = e || window.event;
                    
        switch (e.keyCode) {
            case 32: // Spacebar
//                if (!inGame) {
//                    startGame();
//                }
                break;
                            
            // Prevent turning the snake back on itself.
            case 37: // Left
                if (inGame && snake.heading != 'right')
                    snake.heading = 'left';
                break;
                            
            case 38: // Up
                if (inGame && snake.heading != 'down')
                    snake.heading = 'up';
                break;
                            
            case 39: // Right
                if (inGame && snake.heading != 'left')
                    snake.heading = 'right';
                break;
                            
            case 40: // Down
                if (inGame && snake.heading != 'up')
                    snake.heading = 'down';
                break;
        }
    }
    
    function displayScore() {
        scoreField.innerHTML = score;
    }
    
    function displayTime() {
        gameDuration = Math.floor((new Date().getTime() - startTime) / 1000);
        timeField.innerHTML = gameDuration + 's';
    }
                
    function createTable() {
        table = document.createElement('table');
        for (var y = 0; y < height; y++) {
            var row = table.insertRow(y);
            for (var x = 0; x < width; x++)
                var col = row.insertCell(x);
        }
        div.appendChild(table);
    }
                
    function clearTable() {
        for (var y = 0; y < height; y++) {
            var row = table.rows[y];
            for (var x = 0; x < width; x++) {
                row.cells[x].className = '';
            }
        }
    }
                
    // Returns {x:, y:, tableCell:}
    function getRandomUnoccupiedCell() {
        var cell = {};
                    
        while (!cell.x || !cell.y || !cell.tableCell || cell.tableCell.className != '') {
            cell.x = Math.floor(Math.random() * width);
            cell.y = Math.floor(Math.random() * height);
            cell.tableCell = table.rows[cell.y].cells[cell.x];
        }
                    
        return cell;
    }
                
    function generateApple() {
        apple = getRandomUnoccupiedCell();
        apple.tableCell.className = 'apple';
    }
                
    // Segments are {x:, y:, tableCell:}s
    function generateSnake() {
        snake = {};
        snake.heading = 'right';
        snake.segments = [{x: Math.floor(width / 2), y: Math.floor(height / 2)}];
        snake.segments[0].tableCell = table.rows[snake.segments[0].y].cells[snake.segments[0].x];
        snake.segments[0].tableCell.className = 'snake-segment';
        snake.segmentHeadIndex = 0;
    }
                
    function startGame() {
        inGame = true;
        score = 0;
        startTime = new Date().getTime();
        displayScore();
        displayTime();
        clearTable();
        generateSnake();
        generateApple();
        window.setTimeout(processTimeout, delay);
    }
                
    function endGame() {
        inGame = false;
        grayOutBoard();
        checkAndSetHighScore();
        displayHighScore();
    }
    
    function grayOutBoard() {
        for (var i = 0; i < snake.segments.length; i++)
            snake.segments[i].tableCell.className = 'dead';
        if (apple)
            apple.tableCell.className = 'dead';
    }
    
    function checkAndSetHighScore() {
        var highScore = getHighScore();
        
        if (score > highScore)
            setHighScore(score);
    }
    
    // Returns 0 if no high score set.
    function getHighScore() {
        var key = 'snake-high-score';
        var startIndex = document.cookie.indexOf(key + '=');
        
        if (startIndex > -1) {
            var endIndex = document.cookie.indexOf(';', startIndex);
            if (endIndex == -1)
                endIndex = document.cookie.length;
            
            return document.cookie.substring(startIndex + key.length + 1, endIndex);
        }
        
        return 0;
    }
    
    function setHighScore(highScore) {
        document.cookie = 'snake-high-score=' + highScore + '; expires=Fri, 31 Dec 2099 23:59:59 GMT;';
    }
    
    function displayHighScore() {
        highScoreField.innerHTML = getHighScore();
    }
    
    function processTimeout() {
        var snakeHead = snake.segments[snake.segmentHeadIndex];
        var nextCell = {x: snakeHead.x, y: snakeHead.y};
        
        displayTime();
                    
        // Apply directional heading to nextCell.
        switch (snake.heading) {
            case 'left':
                nextCell.x--;
                break;
                            
            case 'up':
                nextCell.y--;
                break;
                            
            case 'right':
                nextCell.x++;
                break;
                            
            case 'down':
                nextCell.y++;
                break;
        }
                    
        if (checkSegmentAgainstBoundsAndSelf(nextCell)) {
            nextCell.tableCell = table.rows[nextCell.y].cells[nextCell.x];
                        
            if (checkSegmentAgainstApple(nextCell)) {
                score++;
                displayScore();
                addSegmentToHead(nextCell);
                generateApple();
            } else {
                removeTailAndAddSegmentToHead(nextCell);
            }
                            
            window.setTimeout(processTimeout, delay);
        } else
            endGame();
    }
                
    function addSegmentToHead(segment) {
        var newSegments = new Array(snake.segments.length + 1);
                    
        newSegments[0] = segment;
        // Copy over the remaining segments.
        for (var i = 0; i < snake.segments.length; i++) {
            var j = i + snake.segmentHeadIndex;
                        
            if (j >= snake.segments.length)
                j -= snake.segments.length;
                        
            newSegments[i + 1] = snake.segments[j];
        }
                    
        snake.segments = newSegments;
        snake.segmentHeadIndex = 0;
                    
        snake.segments[0].tableCell.className = 'snake-segment';
    }
                
    function removeTailAndAddSegmentToHead(segment) {
        var newHeadIndex = snake.segmentHeadIndex;
                    
        newHeadIndex--;
        if (newHeadIndex < 0)
            newHeadIndex = snake.segments.length - 1;
                    
        snake.segments[newHeadIndex].tableCell.className = '';
        segment.tableCell.className = 'snake-segment';
                    
        snake.segments[newHeadIndex] = segment;
        snake.segmentHeadIndex = newHeadIndex;
    }
                
    // Check the segment position against bounds and itself.  False if invalid.
    function checkSegmentAgainstBoundsAndSelf(segment) {
        if (segment.x < 0 || segment.y < 0 || segment.x >= width || segment.y >= height)
            return false;
        for (var i = 0; i < snake.segments.length; i++)
            if (segment.x == snake.segments[i].x && segment.y == snake.segments[i].y)
                return false;
                    
        return true;
    }
                
    // Returns true if segment at the same cell as the apple.
    function checkSegmentAgainstApple(segment) {
        if (segment.x == apple.x && segment.y == apple.y)
            return true;
                    
        return false;
    }
}
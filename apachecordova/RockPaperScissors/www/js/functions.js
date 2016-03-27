function handleUserChoice(userChoice) {
    //0 - rock, 1 - paper, 2 - scissors
    var computerChoice = getRandomInt(0, 2);
    var computerElement = document.getElementById("computer-choice");
    var userElement = document.getElementById("user-choice");
   
    switch (userChoice) {
        case 0:
            if (computerChoice == 0) {
                handleUserChoice("rock");
            } else if (computerChoice == 1) {
                showResultsToUser(false);
                computerElement.innerHTML = "Computer: PAPER";
            } else {
                showResultsToUser(true);
                computerElement.innerHTML = "Computer: SCISSORS";
            }
            
            userElement.innerHTML = "You: ROCK";
        break;
        case 1:
            if (computerChoice == 1) {
                handleUserChoice("paper");
            } else if (computerChoice == 0) {
                showResultsToUser(true);
                computerElement.innerHTML = "Computer: ROCK";
            } else {
                showResultsToUser(false);
                computerElement.innerHTML = "Computer: SCISSORS";
            }
            
            userElement.innerHTML = "You: PAPER";
        break;
        case 2:
            if (computerChoice == 2) {
                handleUserChoice("scissors");
            } else if (computerChoice == 1) {
                showResultsToUser(true);
                computerElement.innerHTML = "Computer: PAPER";
            } else {
                showResultsToUser(false);
                computerElement.innerHTML = "Computer: ROCK";
            }
            
            userElement.innerHTML = "You: SCISSORS";
        break;
    }
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function showResultsToUser(didUserWin) {
     document.getElementById("result").innerHTML = didUserWin ? "YOU WON!" : "YOU LOST!";
}
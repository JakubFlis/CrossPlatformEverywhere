function handleUserChoice(userChoice) {
    //0 - rock, 1 - paper, 2 - scissors
    var computerElement = document.getElementById("computer-choice");
    var userElement = document.getElementById("user-choice");
    var computerChoice = getRandomInt(0, 2);
    setChoiceImage(computerChoice, false);
   
    switch (userChoice) {
        case 0:
            if (computerChoice == 0) {
                handleUserChoice(0);
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
                handleUserChoice(1);
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
                handleUserChoice(2);
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
    
    setChoiceImage(userChoice, true);
}

function setChoiceImage(choice, isUserChoice) {
    var source = ""
     switch (choice) {
         case 0:
             source = "img/rock";
            break;
         case 1:
            source = "img/paper";
            break;
         case 2:
            source = "img/scissors";
            break;
     }
     
    source = source.concat(isUserChoice ? ".png" : "_op.png");
    document.getElementById(isUserChoice ? "user-choice-image" : "computer-choice-image").src = source;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function showResultsToUser(didUserWin) {
    var resultElement = document.getElementById("result");
    resultElement.innerHTML = didUserWin ? "YOU WON!" : "YOU LOST!";
    resultElement.style.color = didUserWin ? "Green" : "Red";
}
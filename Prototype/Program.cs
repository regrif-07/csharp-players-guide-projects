using Utility;

const int MinPuzzledNum = 0;
const int MaxPuzzledNum = 100;

var puzzledNum = InputUtility.AskUserForValueInRange(
    MinPuzzledNum,
    MaxPuzzledNum,
    $"User 1, enter a number between {MinPuzzledNum} and {MaxPuzzledNum}: ");
Console.Clear();

Console.WriteLine("User 2, guess the number.");
while (true)
{
    var playerGuess = InputUtility.AskUserForValueInRange(
        MinPuzzledNum,
        MaxPuzzledNum, 
        $"What is your next guess (in the range from {MinPuzzledNum} to {MaxPuzzledNum})? ");

    if (playerGuess < puzzledNum)
    {
        Console.WriteLine($"{playerGuess} is too low.");
    }
    else if (playerGuess > puzzledNum)
    {
        Console.WriteLine($"{playerGuess} is too high.");
    }
    else
    {
        break;
    }
}

Console.WriteLine("You guessed the number!");
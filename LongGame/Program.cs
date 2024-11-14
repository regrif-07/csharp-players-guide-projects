using Utility;

var playerName = InputUtility.AskUserForValue<string>("Enter your name: "); // use this method to avoid the null value
var playerScoreFilepath = $"{playerName}.score";

int playerScore;
if (File.Exists(playerScoreFilepath))
{
    if (!int.TryParse(File.ReadAllText(playerScoreFilepath), out playerScore))
    {
        Console.WriteLine($"Error: your score file (\"{playerScoreFilepath}\") is corrupted!" +
            " Delete it (you will lose your score), or login with another name.");
        return;
    }

    Console.WriteLine($"Successfully loaded your score! Your score is {playerScore}.");
}
else
{
    playerScore = 0;
    Console.WriteLine($"No previous score was found. Starting from {playerScore}.");
}

Console.WriteLine("\nPress buttons to earn score (press the ENTER key to exit):");
while (true)
{
    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
    {
        break;
    }

    Console.WriteLine(++playerScore);
}

File.WriteAllText(playerScoreFilepath, playerScore.ToString());
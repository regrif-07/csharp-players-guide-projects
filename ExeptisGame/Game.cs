using Utility;

namespace ExceptisGame;

internal class Game
{
    private const int MinCookieNum = 0;
    private const int MaxCookieNum = 9;

    private readonly Player _firstPlayer;
    private readonly Player _secondPlayer;
    private Player _currentPlayer;


    public Game(Player firstPlayer, Player secondPlayer)
    {
        _firstPlayer = firstPlayer;
        _secondPlayer = secondPlayer;
        _currentPlayer = _firstPlayer;
    }

    // throws the GameEndException when the game ends
    public void StartGame()
    {
        var oatmealRaisinCookieNum = Random.Shared.Next(MinCookieNum, MaxCookieNum + 1);

        var selectedCookieNums = new List<int>();
        while (true)
        {
            Console.WriteLine($"{_currentPlayer.Name}, it is your turn.");
            int currentPlayerCookieNum = InputUtility.AskUserForValueInRange(
                MinCookieNum,
                MaxCookieNum,
                $"Enter the number of the cookie to eat ({MinCookieNum}-{MaxCookieNum}): ");

            if (selectedCookieNums.Contains(currentPlayerCookieNum))
            {
                Console.WriteLine("This cookie was already eaten! Select another odne.\n");
                continue;
            }

            if (currentPlayerCookieNum == oatmealRaisinCookieNum)
            {
                Console.WriteLine("Oh no! It was the awful oatmeal raisin cookie...");
                throw new GameEndException(GetOppositePlayer());
            }

            Console.WriteLine("You ate a delicious chocolate chip cookie!\n");

            selectedCookieNums.Add(currentPlayerCookieNum);
            SwitchCurrentPlayer();
        }
    }

    private Player GetOppositePlayer() => (_currentPlayer == _firstPlayer) ? _secondPlayer : _firstPlayer;
    private void SwitchCurrentPlayer() => _currentPlayer = GetOppositePlayer();
}

internal record Player(string Name);

internal class GameEndException : Exception
{
    public GameEndException(Player winner) : base($"{winner.Name} won the game")
    {
        Winner = winner;
    }

    public Player Winner { get; }
}
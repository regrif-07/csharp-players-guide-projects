using TicTacToe;
using TicTacToe.BoardComponents;
using TicTacToe.GameControllers;

var ticTacToeGame = new Game(new Board(), new BoardDisplayer(), new PlayerGameController(), new RandomBotGameController());
string endMessage = ticTacToeGame.Start() switch
{
    BoardStatus.InProcess => throw new InvalidOperationException("game ended with InProcess status"),
    BoardStatus.CrossVictory => "You have won!",
    BoardStatus.ZeroVictory => "You have lost...",
    BoardStatus.Draw => "It's a draw.",
    BoardStatus.Impossible => throw new InvalidOperationException("game ended up with impossible state"),
    _ => throw new NotImplementedException()
};

Console.WriteLine($"\n{endMessage}");

using TicTacToe.BoardComponents;

namespace TicTacToe.GameControllers;

internal class RandomBotGameController : IGameController
{
    private const int BotSleepTimeMs = 1000;

    public (int, int) GetNextMoveTargetIndices(Board board)
    {
        Console.WriteLine("Computer is making its move...");
        Thread.Sleep(BotSleepTimeMs);

        var freeCellsIndices = board.GetFreeCellsIndices();
        if (freeCellsIndices.Count == 0)
        {
            throw new InvalidOperationException("random bot game controller can't make a move: game board is already full");
        }

        return freeCellsIndices[Random.Shared.Next(freeCellsIndices.Count)];
    }
}
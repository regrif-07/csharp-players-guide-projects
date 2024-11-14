using TicTacToe.BoardComponents;

namespace TicTacToe.GameControllers;

internal interface IGameController
{
    public (int, int) GetNextMoveTargetIndices(Board board);
}

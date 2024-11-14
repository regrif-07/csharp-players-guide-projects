using TicTacToe.BoardComponents;
using TicTacToe.GameControllers;

namespace TicTacToe;

internal class Game
{
    private readonly Board _board;
    private readonly BoardDisplayer _boardDisplayer;
    private readonly IGameController _crossGameController;
    private readonly IGameController _zeroGameController;

    private bool _isCrossTurn = true;

    public Game(Board board, BoardDisplayer boardDisplayer, IGameController crossGameController, IGameController zeroGameController)
    {
        _board = board;
        _boardDisplayer = boardDisplayer;
        _crossGameController = crossGameController;
        _zeroGameController = zeroGameController;
    }

    public BoardStatus Start()
    {
        BoardStatus currentGameStatus = BoardStatusAnalyzer.Analyze(_board);
        while (true)
        {
            var currentTurnCell = _isCrossTurn ? Cell.Cross : Cell.Zero;
            Console.WriteLine($"It is {_boardDisplayer.CellToChar(currentTurnCell)}'s turn.");

            _boardDisplayer.Display(_board);

            var (nextMoveRowIndex, nextMoveColumnIndex) = (_isCrossTurn ? _crossGameController : _zeroGameController).GetNextMoveTargetIndices(_board);
            _board.SetCellAt(nextMoveRowIndex, nextMoveColumnIndex, currentTurnCell);

            currentGameStatus = BoardStatusAnalyzer.Analyze(_board);

            if (currentGameStatus != BoardStatus.InProcess)
            {
                Console.WriteLine();
                _boardDisplayer.Display(_board); // display the final state of the board

                return currentGameStatus;
            }

            _isCrossTurn = !_isCrossTurn;

            Console.WriteLine();
        }
    }
}

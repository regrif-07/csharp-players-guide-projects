namespace TicTacToe.BoardComponents;

internal enum BoardStatus
{
    InProcess,
    CrossVictory,
    ZeroVictory,
    Draw,
    Impossible, // the board state is impossible
}

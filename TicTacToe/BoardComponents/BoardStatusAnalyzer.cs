namespace TicTacToe.BoardComponents;

internal static class BoardStatusAnalyzer
{
    public static BoardStatus Analyze(Board board)
    {
        var crossCells = CountCells(board, Cell.Cross);
        var zeroCells = CountCells(board, Cell.Zero);
        var crossLines = CountCellLines(board, Cell.Cross);
        var zeroLines = CountCellLines(board, Cell.Zero);

        if (Math.Abs(crossCells - zeroCells) > 1 || crossLines > 0 && zeroLines > 0)
        {
            return BoardStatus.Impossible;
        }
        if (crossLines > 0)
        {
            return BoardStatus.CrossVictory;
        }
        if (zeroLines > 0)
        {
            return BoardStatus.ZeroVictory;
        }
        if (crossCells + zeroCells == Board.Height * Board.Width)
        {
            return BoardStatus.Draw;
        }

        return BoardStatus.InProcess;
    }

    private static int CountCells(Board board, Cell targetCell)
    {
        int cellCounter = 0;
        for (int rowIndex = 0; rowIndex < Board.Height; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < Board.Width; ++columnIndex)
            {
                if (board.GetCellAt(rowIndex, columnIndex) == targetCell)
                {
                    ++cellCounter;
                }
            }
        }

        return cellCounter;
    }

    private static int CountCellLines(Board board, Cell targetCell) =>
        CountHorizontalLines(board, targetCell) + CountVerticalLines(board, targetCell) + CountDiagonalLines(board, targetCell);

    private static int CountHorizontalLines(Board board, Cell targetCell)
    {
        var horizontalLinesCounter = 0;

        for (var rowIndex = 0; rowIndex < Board.Height; ++rowIndex)
        {
            bool isLine = true;
            for (var columnIndex = 0; columnIndex < Board.Width; ++columnIndex)
            {
                if (board.GetCellAt(rowIndex, columnIndex) != targetCell)
                {
                    isLine = false;
                    break;
                }
            }

            if (isLine)
            {
                ++horizontalLinesCounter;
            }
        }

        return horizontalLinesCounter;
    }

    private static int CountVerticalLines(Board board, Cell targetCell)
    {
        var verticalLinesCounter = 0;

        for (var columnIndex = 0; columnIndex < Board.Width; ++columnIndex)
        {
            bool isLine = true;
            for (var rowIndex = 0; rowIndex < Board.Height; ++rowIndex)
            {
                if (board.GetCellAt(rowIndex, columnIndex) != targetCell)
                {
                    isLine = false;
                    break;
                }
            }

            if (isLine)
            {
                ++verticalLinesCounter;
            }
        }

        return verticalLinesCounter;
    }

    private static int CountDiagonalLines(Board board, Cell targetCell)
    {
        var diagonalLineCounter = 2;

        for (int rowIndex = 0, columnIndex = 0;
            rowIndex < Board.Height && columnIndex < Board.Width;
            ++rowIndex, ++columnIndex)
        {
            if (board.GetCellAt(rowIndex, columnIndex) != targetCell)
            {
                --diagonalLineCounter;
                break;
            }
        }

        for (int rowIndex = 0, columnIndex = Board.Width - 1;
            rowIndex < Board.Height && columnIndex >= 0;
            ++rowIndex, --columnIndex)
        {
            if (board.GetCellAt(rowIndex, columnIndex) != targetCell)
            {
                --diagonalLineCounter;
                break;
            }
        }

        return diagonalLineCounter;
    }
}

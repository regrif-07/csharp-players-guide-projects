namespace TicTacToe.BoardComponents;

internal class BoardDisplayer
{
    public char EmptyCellChar { get; init; } = ' ';
    public char CrossCellChar { get; init; } = 'X';
    public char ZeroCellChar { get; init; } = 'O';

    public char HorizontalDelimiterChar { get; init; } = '|';
    public char VerticalDelimiterChar { get; init; } = '-';
    public char CornerChar { get; init; } = '+';

    public void Display(Board board)
    {
        var verticalDelimiter = ConstructVerticalDelimiter();
        var horizontalDelimiter = $" {HorizontalDelimiterChar} ";

        for (int rowIndex = 0; rowIndex < Board.Height; ++rowIndex)
        {
            var rowCellChars = new char[Board.Width];
            for (int columnIndex = 0; columnIndex < Board.Width; ++columnIndex)
            {
                rowCellChars[columnIndex] = CellToChar(board.GetCellAt(rowIndex, columnIndex));
            }

            Console.WriteLine($" {string.Join(horizontalDelimiter, rowCellChars)} ");

            if (rowIndex < Board.Height - 1)
            {
                Console.WriteLine(verticalDelimiter);
            }
        }
    }

    public char CellToChar(Cell cell) => cell switch
    {
        Cell.Empty => EmptyCellChar,
        Cell.Cross => CrossCellChar,
        Cell.Zero => ZeroCellChar,
        _ => throw new NotImplementedException(),
    };

    private string ConstructVerticalDelimiter()
    {
        var cellVerticalDelimiter = new string(VerticalDelimiterChar, 3);
        return $"{cellVerticalDelimiter}{CornerChar}{cellVerticalDelimiter}{CornerChar}{cellVerticalDelimiter}";
    }
}

namespace TicTacToe.BoardComponents;

internal enum Cell
{
    Empty,
    Cross,
    Zero,
}

internal class Board
{
    public const int Height = 3;
    public const int Width = 3;

    private Cell[,] _cellMatrix;

    public Board()
    {
        _cellMatrix = new Cell[Width, Height];
        Reset();
    }

    public void Reset()
    {
        for (int rowIndex = 0; rowIndex < Height; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < Width; ++columnIndex)
            {
                _cellMatrix[rowIndex, columnIndex] = Cell.Empty;
            }
        }
    }

    public Cell GetCellAt(int rowIndex, int columnIndex)
    {
        ThrowIfCellIndicesNotValid(rowIndex, columnIndex);

        return _cellMatrix[rowIndex, columnIndex];
    }

    public void SetCellAt(int rowIndex, int columnIndex, Cell cell)
    {
        ThrowIfCellIndicesNotValid(rowIndex, columnIndex);

        if (IsCellOccupied(rowIndex, columnIndex))
        {
            throw new InvalidOperationException($"can't set cell at ({rowIndex}, {columnIndex}): the cell is not empty");
        }

        _cellMatrix[rowIndex, columnIndex] = cell;
    }

    public List<(int, int)> GetFreeCellsIndices()
    {
        var freeCellIndices = new List<(int, int)>();

        for (int rowIndex = 0; rowIndex < Height; ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < Width; ++columnIndex)
            {
                if (_cellMatrix[rowIndex, columnIndex] == Cell.Empty)
                {
                    freeCellIndices.Add((rowIndex, columnIndex));
                }
            }
        }

        return freeCellIndices;
    }

    public bool AreCellIndicesValid(int rowIndex, int columnIndex) => rowIndex >= 0 || rowIndex < Height && columnIndex >= 0 && columnIndex < Width;

    public bool IsCellOccupied(int rowIndex, int columnIndex) => _cellMatrix[rowIndex, columnIndex] != Cell.Empty;

    private void ThrowIfCellIndicesNotValid(int rowIndex, int columnIndex)
    {
        if (!AreCellIndicesValid(rowIndex, columnIndex))
        {
            throw new IndexOutOfRangeException("cell indices are out of range");
        }
    }
}
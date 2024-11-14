internal struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacentTo(Coordinate other)
    {
        var rowDiff = Row - other.Row;
        var columnDiff = Column - other.Column;

        if (Math.Abs(rowDiff) <= 1 && columnDiff == 0) return true;
        if (Math.Abs(columnDiff) <= 1 && rowDiff == 0) return true;

        return false;
    }

    public override string ToString() => $"({Row}, {Column})";
}
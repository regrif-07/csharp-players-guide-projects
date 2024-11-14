
internal record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coord, BlockOffset offset) 
        => new BlockCoordinate(coord.Row + offset.RowOffset, coord.Column + offset.ColumnOffset);

    public static BlockCoordinate operator +(BlockCoordinate coord, Direction direction) => coord + (BlockOffset)direction;

    public int this[int num]
    {
        get => num switch
        {
            0 => Row,
            1 => Column,
            _ => throw new IndexOutOfRangeException("0 for row, 1 for column, other = invalid")
        };
    }

}

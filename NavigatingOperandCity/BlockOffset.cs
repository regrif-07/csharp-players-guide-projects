
internal record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction) => direction switch
    {
        Direction.North => new BlockOffset(-1, 0),
        Direction.East => new BlockOffset(0, 1),
        Direction.South => new BlockOffset(1, 0),
        Direction.West => new BlockOffset(0, -1),
        _ => throw new NotImplementedException()
    };
}

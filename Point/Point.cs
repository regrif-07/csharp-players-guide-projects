internal class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point() : this(0, 0)
    { 
    }

    public int X { get; }
    public int Y { get; }


    public override string ToString() => $"({X}, {Y})";
}
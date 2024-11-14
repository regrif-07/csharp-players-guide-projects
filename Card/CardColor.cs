internal enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow,
}

internal static class CardColorExtensions
{
    public static string GetSymbol(this CardColor color) => color switch
    {
        CardColor.Red => "R",
        CardColor.Green => "G",
        CardColor.Blue => "B",
        CardColor.Yellow => "Y",
        _ => throw new NotImplementedException()
    };
}

internal enum ArrowheadType
{
    Steel,
    Wood,
    Obsidian,
}

internal static class ArrowheadTypeExtensions
{
    public static float GetCost(this ArrowheadType arrowheadType) => arrowheadType switch
    {
        ArrowheadType.Steel => 10.0f,
        ArrowheadType.Wood => 3.0f,
        ArrowheadType.Obsidian => 5.0f,
        _ => throw new NotImplementedException()
    };
}
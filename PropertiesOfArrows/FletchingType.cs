internal enum FletchingType
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers,
}

internal static class FletchingTypeExtensions
{
    public static float GetCost(this FletchingType fletchingType) => fletchingType switch
    {
        FletchingType.Plastic => 10.0f,
        FletchingType.TurkeyFeathers => 5.0f,
        FletchingType.GooseFeathers => 3.0f,
        _ => throw new NotImplementedException()
    };
}

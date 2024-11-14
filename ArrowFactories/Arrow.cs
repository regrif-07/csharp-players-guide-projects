internal class Arrow
{
    private const float ShaftLengthPricePerCm = 0.05f;

    public ArrowheadType ArrowheadType { get; }
    public FletchingType FletchingType { get; }
    public float ShaftLengthCm { get; }

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, float shaftLengthCm)
    {
        ArrowheadType = arrowheadType;
        FletchingType = fletchingType;
        ShaftLengthCm = shaftLengthCm;
    }

    public static Arrow CreateEliteArrow() => new Arrow(ArrowheadType.Steel, FletchingType.Plastic, 95.0f);
    public static Arrow CreateBeginnerArrow() => new Arrow(ArrowheadType.Wood, FletchingType.GooseFeathers, 75.0f);
    public static Arrow CreateMarksmanArrow() => new Arrow(ArrowheadType.Steel, FletchingType.GooseFeathers, 65.0f);

    public float GetCost() => ArrowheadType.GetCost() + FletchingType.GetCost() + ShaftLengthCm * ShaftLengthPricePerCm;
}
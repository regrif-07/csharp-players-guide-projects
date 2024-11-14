internal class Arrow
{
    private const float ShaftLengthPricePerCm = 0.05f;

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, float shaftLengthCm)
    {
        ArrowheadType = arrowheadType;
        FletchingType = fletchingType;
        ShaftLengthCm = shaftLengthCm;
    }

    public ArrowheadType ArrowheadType { get; }
    public FletchingType FletchingType { get; }
    public float ShaftLengthCm { get; }

    public float GetCost() => ArrowheadType.GetCost() + FletchingType.GetCost() + ShaftLengthCm * ShaftLengthPricePerCm;
}
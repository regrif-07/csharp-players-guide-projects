internal class Arrow
{
    private const float ShaftLengthPricePerCm = 0.05f;

    private ArrowheadType _arrowheadType;
    private FletchingType _fletchingType;
    private float _shaftLengthCm;

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, float shaftLengthCm)
    {
        _arrowheadType = arrowheadType;
        _fletchingType = fletchingType;
        _shaftLengthCm = shaftLengthCm;
    }

    public ArrowheadType GetArrowheadType() => _arrowheadType;
    public FletchingType GetFletchingType() => _fletchingType;
    public float GetShaftLengthCm() => _shaftLengthCm;

    public float GetCost() => _arrowheadType.GetCost() + _fletchingType.GetCost() + _shaftLengthCm * ShaftLengthPricePerCm;
}
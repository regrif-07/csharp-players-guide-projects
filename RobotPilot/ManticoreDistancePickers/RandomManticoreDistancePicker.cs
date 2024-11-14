internal class RandomManticoreDistancePicker : IManticoreDistancePicker
{
    public int PickManticoreDistnace() => Random.Shared.Next(ManticoreConstants.MinDistance, ManticoreConstants.MaxDistance + 1);
}
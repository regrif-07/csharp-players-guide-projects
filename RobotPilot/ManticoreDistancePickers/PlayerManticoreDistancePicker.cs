using Utility;

internal class PlayerManticoreDistancePicker : IManticoreDistancePicker
{
    public int PickManticoreDistnace() => InputUtility.AskUserForValueInRange(
        ManticoreConstants.MinDistance,
        ManticoreConstants.MaxDistance,
        "How far away from the city do you want to station the Manticore? ");
}

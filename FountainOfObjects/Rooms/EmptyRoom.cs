namespace FountainOfObjects.Rooms;

internal class EmptyRoom : Room
{
    public override void OnPlayerInside(Game game) { }

    public override void OnPlayerNearby(Game game) { }
}

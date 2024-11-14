namespace FountainOfObjects.Rooms;

internal class PitRoom : Room
{
    public PitRoom() : base(ConsoleColor.White) { }

    public override void OnPlayerInside(Game game)
    {
        WriteColoredMessage("You have fallen into the pit!");
        game.Player.IsAlive = false;
        game.InProcess = false;
    }

    public override void OnPlayerNearby(Game game)
    {
        WriteColoredMessage("You feel a draft. There is a pit in a nearby room.");
    }
}

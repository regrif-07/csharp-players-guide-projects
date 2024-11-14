namespace FountainOfObjects.Rooms;

internal class FountainRoom : Room
{
    public FountainRoom() : base(ConsoleColor.Blue) { }

    public bool IsFountainActive { get; set; } = false;

    public override void OnPlayerInside(Game game)
    {
        if (IsFountainActive)
        {
            WriteColoredMessage("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
        }
        else
        {
            WriteColoredMessage("You hear water dripping in this room. The Fountain of Objects is here!");
        }
    }

    public override void OnPlayerNearby(Game game) { }
}
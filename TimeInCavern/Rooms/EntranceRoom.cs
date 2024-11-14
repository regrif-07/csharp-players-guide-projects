namespace FountainOfObjects.Rooms;

internal class EntranceRoom : Room
{
    public EntranceRoom() : base(ConsoleColor.Yellow) { }

    public override void OnPlayerInside(Game game)
    {
        WriteColoredMessage("You see light in this room coming from outside the cavern. This is the entrance.");

        if (game.Cavern.FountainRoom.IsFountainActive)
        {
            game.InProcess = false;
        }
    }

    public override void OnPlayerNearby(Game game) { }
}

namespace FountainOfObjects.Rooms;

internal class AmarokRoom : Room
{
    public AmarokRoom() : base(ConsoleColor.Red) { }

    public override void OnPlayerInside(Game game)
    {
        WriteColoredMessage("Upon entering the room, something pounced on you from the darkness of the far corner! Amarok tore you apart...");
        game.Player.IsAlive = false;
        game.InProcess = false;
    }

    public override void OnPlayerNearby(Game game)
    {
        WriteColoredMessage("You can smell the rotten stench of an amarok in a nearby room.");
    }
}

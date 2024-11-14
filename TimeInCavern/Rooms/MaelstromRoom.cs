namespace FountainOfObjects.Rooms;

internal class MaelstromRoom : Room
{
    public MaelstromRoom() : base(ConsoleColor.DarkCyan) { }

    public override void OnPlayerInside(Game game)
    {
        WriteColoredMessage("You stumble upon maelstrom! A strong wind lifts you up and carries you away in an unknown direction...");

        var playerPosition = game.Player.Position;

        var maelstromNewPosition = new RoomPosition(
            Math.Clamp(playerPosition.Row + 1, 0, game.Cavern.Height - 1), 
            Math.Clamp(playerPosition.Column - 2, 0, game.Cavern.Width - 1));
        // if the maelstrom's room is empty, place it there
        if (game.Cavern.GetRoomAt(maelstromNewPosition) is EmptyRoom)
        {
            game.Cavern.SetRoomAt(maelstromNewPosition, this);
        }
        game.Cavern.SetRoomAt(playerPosition, new EmptyRoom()); // either way, the current room should be empty
        // in the end, if maelstrom's target position was occupied, the maelstrom disappears

        var playerNewPosition = new RoomPosition(
            Math.Clamp(playerPosition.Row - 1, 0, game.Cavern.Height - 1),
            Math.Clamp(playerPosition.Column + 2, 0, game.Cavern.Width - 1));
        game.Player.Position = playerNewPosition;
        
        game.RequestGameLoopReset(); // player location was updated, game loop reset is required
    }

    public override void OnPlayerNearby(Game game)
    {
        WriteColoredMessage("You hear the growling and groaning of a maelstrom nearby.");
    }
}

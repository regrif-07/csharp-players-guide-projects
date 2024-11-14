using Utility;

namespace FountainOfObjects.Rooms;

internal abstract class Room
{
    private readonly ConsoleColor? _messageColor;

    public Room()
    {
        _messageColor = null;
    }

    public Room(ConsoleColor messageColor)
    {
        _messageColor = messageColor;
    }

    abstract public void OnPlayerInside(Game game);
    abstract public void OnPlayerNearby(Game game);

    protected void WriteColoredMessage(string? message) => OutputUtility.WriteLineColored(message, _messageColor);
}

namespace FountainOfObjects.PlayerComponents;

internal class Player
{
    public Player(RoomPosition initialPosition, int initialArrowsNumber)
    {
        Position = initialPosition;
        ArrowsLeft = initialArrowsNumber;
    }

    public RoomPosition Position { get; set; }
    public int ArrowsLeft { get; set; }
    public bool IsAlive { get; set; } = true;
}

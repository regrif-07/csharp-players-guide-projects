namespace FountainOfObjects;

internal record struct RoomPosition(int Row, int Column)
{
    public override string ToString() => $"(Row={Row}, Column={Column})";

    public IEnumerable<RoomPosition> GetAdjacentRoomsCoordinates()
    {
        var adjacentRoomsCoordinates = new List<RoomPosition>();
        for (int rowOffset = -1; rowOffset <= 1; ++rowOffset)
        {
            for (int columnOffset = -1; columnOffset <= 1; ++columnOffset)
            {
                adjacentRoomsCoordinates.Add(new RoomPosition(Row + rowOffset, Column + columnOffset));
            }
        }

        return adjacentRoomsCoordinates;
    }

    public RoomPosition AddByDirectionName(string directionName)
    {
        var updatedRoomPosition = this;
        switch (directionName.Trim().ToLower())
        {
            case "north": --updatedRoomPosition.Row;   break;
            case "south": ++updatedRoomPosition.Row;   break;
            case "west":  --updatedRoomPosition.Column; break;
            case "east":  ++updatedRoomPosition.Column; break;
            default:      throw new ArgumentException("invalid direction name");
        }

        return updatedRoomPosition;
    }
}

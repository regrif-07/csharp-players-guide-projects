using FountainOfObjects.Rooms;

namespace FountainOfObjects.CavernComponents;

internal class Cavern
{
    private Room[,] _roomsMatrix;

    public Cavern(Room[,] roomsMatrix)
    {
        Height = roomsMatrix.GetLength(0);
        Width = roomsMatrix.GetLength(1);

        if (Height <= 0 || Width <= 0)
        {
            throw new ArgumentException("rooms matrix cannot be empty");
        }

        _roomsMatrix = roomsMatrix;

        var fountainRoomsPositions = FindAllRoomPositionsByType<FountainRoom>();
        if (fountainRoomsPositions.Count() != 1)
        {
            throw new ArgumentException("cavern should contain exactly one fountain room");
        }
        FountainRoomPosition = fountainRoomsPositions[0];
        FountainRoom = (FountainRoom)_roomsMatrix[FountainRoomPosition.Row, FountainRoomPosition.Column];

        var entranceRoomsPositions = FindAllRoomPositionsByType<EntranceRoom>();
        if (entranceRoomsPositions.Count() != 1)
        {
            throw new ArgumentException("cavern should contain exactly one entrance room");
        }
        EntranceRoomPosition = entranceRoomsPositions[0];
    }

    public int Height { get; }
    public int Width { get; }

    public RoomPosition FountainRoomPosition { get; }
    public FountainRoom FountainRoom { get; }

    public RoomPosition EntranceRoomPosition { get; }

    public Room GetRoomAt(RoomPosition roomPosition)
    {
        CheckRoomPosition(roomPosition);
        return _roomsMatrix[roomPosition.Row, roomPosition.Column];
    }

    public void SetRoomAt(RoomPosition roomPosition, Room room)
    {
        CheckRoomPosition(roomPosition);
        _roomsMatrix[roomPosition.Row, roomPosition.Column] = room;
    }

    public bool IsValidRoomPosition(RoomPosition roomPosition)
    {
        if (roomPosition.Row < 0 || roomPosition.Column < 0 || roomPosition.Row >= Height || roomPosition.Column >= Width)
        {
            return false;
        }

        return true;
    }
    public List<RoomPosition> FindAllRoomPositionsByType<TRoom>() where TRoom : Room
    {
        var roomPositions = new List<RoomPosition>();
        foreach (var roomPosition in GenerateAllRoomsCoordinates())
        {
            if (_roomsMatrix[roomPosition.Row, roomPosition.Column] is TRoom)
            {
                roomPositions.Add(roomPosition);
            }
        }

        return roomPositions;
    }

    // generates all coordinates of rooms in a cavern using its sizes
    public IEnumerable<RoomPosition> GenerateAllRoomsCoordinates()
    {
        for (int row = 0; row < Height; ++row)
        {
            for (int column = 0; column < Width; ++column)
            {
                yield return new RoomPosition(row, column);
            }
        }
    }

    // throws exception if the provided room position is invalid/out of bounds
    private void CheckRoomPosition(RoomPosition roomPosition)
    {
        if (!IsValidRoomPosition(roomPosition)) throw new ArgumentException("invalid room position");
    }
}

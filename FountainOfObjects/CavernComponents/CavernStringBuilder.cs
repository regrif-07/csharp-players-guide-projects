using FountainOfObjects.Rooms;

namespace FountainOfObjects.CavernComponents;

// builds a cavern from string
internal static class CavernStringBuilder
{
    public static Cavern Build(string cavernString, int cavernHeight, int cavernWidth)
    {
        if (cavernString.Length != cavernHeight * cavernWidth)
        {
            throw new ArgumentException("cavern string has invalid length for provided cavern sizes");
        }

        var cavernRoomsMatrix = new Room[cavernHeight, cavernWidth];
        for (int charIndex = 0; charIndex < cavernString.Length; ++charIndex)
        {
            cavernRoomsMatrix[charIndex / cavernWidth, charIndex % cavernWidth] = CharToRoom(cavernString[charIndex]);
        }

        return new Cavern(cavernRoomsMatrix);
    }

    private static Room CharToRoom(char roomChar) => roomChar switch
    {
        '0' => new EmptyRoom(),
        'E' => new EntranceRoom(),
        'F' => new FountainRoom(),
        'P' => new PitRoom(),
        'A' => new AmarokRoom(),
        'M' => new MaelstromRoom(),
        _ => throw new ArgumentException($"unsupported room char '{roomChar}'")
    };
}

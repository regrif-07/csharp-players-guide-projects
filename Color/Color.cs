
internal class Color
{
    public static readonly Color White = new(255, 255, 255);
    public static readonly Color Black = new(0, 0, 0);
    public static readonly Color Red = new(255, 0, 0);
    public static readonly Color Orange = new(255, 165, 0);
    public static readonly Color Yellow = new(255, 255, 0);
    public static readonly Color Green = new(0, 128, 0);
    public static readonly Color Blue = new(0, 0, 255);
    public static readonly Color Purple = new(128, 0, 128);

    public Color(int redChannel, int greenChannel, int blueChannel)
    {
        RedChannel = redChannel;
        GreenChannel = greenChannel;
        BlueChannel = blueChannel;
    }

    public int RedChannel { get; }
    public int GreenChannel { get; }
    public int BlueChannel { get; }

    public override string ToString() => $"(R: {RedChannel}, G: {GreenChannel}, B: {BlueChannel})";
}
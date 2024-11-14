namespace Utility;

public static class OutputUtility
{
    public static void WriteColored(string? text, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null)
    {
        if (fgColor != null)
        {
            Console.ForegroundColor = (ConsoleColor)fgColor;
        }
        if (bgColor != null)
        {
            Console.BackgroundColor = (ConsoleColor)bgColor;
        }

        Console.Write(text);

        Console.ResetColor();
    }

    public static void WriteLineColored(string? text, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null)
        => WriteColored(text + '\n', fgColor, bgColor);
}

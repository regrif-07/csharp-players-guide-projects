using Utility;

internal class ColoredItem<T>
{
    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public T Item { get; }
    public ConsoleColor Color { get; }

    public void Display()
    {
        OutputUtility.WriteLineColored(Item?.ToString(), Color);
    }
}
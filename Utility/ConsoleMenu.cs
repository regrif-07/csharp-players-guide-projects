namespace Utility;

public class ConsoleMenu<T>
{
    private readonly string? _title;
    private string[] _itemNames;
    private readonly string _numberNameDelimiter;
    private readonly string? _prompt;
    private readonly List<T> _items;

    public ConsoleMenu(string? title, string[] itemNames, string nameNumberDelimiter, string? prompt, params T[] items)
    {
        if (items.Length == 0)
        {
            throw new ArgumentException("ConsoleMenu should contain at least one item");
        }
        if (itemNames.Length != items.Length)
        {
            throw new ArgumentException("number of item names should be equal to the number of items");
        }

        _title = title;
        _itemNames = itemNames;
        _numberNameDelimiter = nameNumberDelimiter;
        _prompt = prompt;
        _items = items.ToList();
    }

    // display menu title and items
    public void DisplayMenu()
    {
        if (_title != null)
        {
            Console.WriteLine(_title);
        }

        for (int itemIndex = 0; itemIndex < _items.Count(); ++itemIndex)
        {
            Console.WriteLine($"{itemIndex + 1}{_numberNameDelimiter}{_itemNames[itemIndex]}");
        }
    }

    public int StartMenuForSelectedIndex()
    {
        DisplayMenu();   

        return InputUtility.AskUserForValueInRange(1, _items.Count(), _prompt) - 1;
    }

    public T StartMenuForSelectedItem() => _items[StartMenuForSelectedIndex()];
}

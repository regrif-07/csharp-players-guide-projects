namespace Utility;

public class ConsoleMenuBuilder<T>
{
    public static Func<T, string> SentenceCasedItemNameExtractor = item => item?.ToString()?.ToSentenceCase() ?? "";

    private string? _title = "Available options:";
    private Func<T, string> _itemNameExtractor = item => item?.ToString() ?? "UNKNOWN";
    private string[]? _fixedItemNames = null;
    private string _numberNameDelimiter = ") ";
    private string? _prompt = "> ";
    private List<T> _items = new List<T>();

    public ConsoleMenuBuilder<T> SetTitle(string? title)
    {
        _title = title;
        return this;
    }

    public ConsoleMenuBuilder<T> SetItemNameExtractor(Func<T, string> itemNameExtractor)
    {
        _itemNameExtractor = itemNameExtractor;
        return this;
    }

    public ConsoleMenuBuilder<T> SetFixedItemNames(params string[] fixedItemNames)
    {
        _fixedItemNames = fixedItemNames;
        return this;
    }

    public ConsoleMenuBuilder<T> SetNumberNameDelimiter(string numberNameDelimiter)
    {
        _numberNameDelimiter = numberNameDelimiter;
        return this;
    }

    public ConsoleMenuBuilder<T> SetPrompt(string? prompt)
    {
        _prompt = prompt;
        return this;
    }

    public ConsoleMenuBuilder<T> AddItems(params T[] items)
    {
        _items.AddRange(items);
        return this;
    }

    public ConsoleMenu<T> Build() 
    {
        var itemNames = (_fixedItemNames == null) 
            ? _items.Select(i => _itemNameExtractor(i)).ToArray() 
            : _fixedItemNames;
        return new(_title, itemNames, _numberNameDelimiter, _prompt, _items.ToArray());
    }
}

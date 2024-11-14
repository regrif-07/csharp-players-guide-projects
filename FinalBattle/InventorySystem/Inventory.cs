using System.Collections.ObjectModel;
using FinalBattle.InventorySystem.Items;
using Utility;

namespace FinalBattle.InventorySystem;

internal class Inventory
{
    private readonly List<IInventoryItem> _items;

    public Inventory(params IInventoryItem[] items)
    {
        _items = items.ToList();
    }

    public bool IsEmpty { get => !_items.Any(); }

    public void AddItems(params IInventoryItem[] items)
    {
        if (items.Length == 0)
        {
            throw new ArgumentException("you can add at least one item");
        }

        _items.AddRange(items);
    }

    public IInventoryItem? GrabItemByIndex(int index)
    {
        var targetItem = _items.ElementAtOrDefault(index);
        if (targetItem != null)
        {
            _items.RemoveAt(index);
        }

        return targetItem;
    }

    public bool HasItemByType<TItem>() where TItem : IInventoryItem => _items.Any(i => i is TItem);

    public IInventoryItem? GrabItemByType<TItem>() where TItem : IInventoryItem
    {
        var targetItem = _items.FirstOrDefault(i => i is TItem);
        if (targetItem != null)
        {
            _items.Remove(targetItem);
        }

        return targetItem;
    }

    public ConsoleMenu<int> BuildItemIndexSelectionMenu() => new ConsoleMenuBuilder<int>()
        .SetTitle("Available items:")
        .SetPrompt("Select the item: ")
        .SetFixedItemNames(_items.Select(i => i.Name).ToArray())
        .AddItems(Enumerable.Range(0, _items.Count).ToArray())
        .Build();
}

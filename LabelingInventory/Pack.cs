internal class Pack
{
    private List<InventoryItem> _items;

    public Pack(int maxItemsNumber, double maxWeight, double maxVolume)
    {
        if (maxItemsNumber <= 0 || maxWeight <= 0.0 || maxVolume <= 0.0)
        {
            throw new ArgumentException("invalid pack properties");
        }

        _items = new();

        MaxItemsNumber = maxItemsNumber;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public int MaxItemsNumber { get; }
    public double MaxWeight { get; }
    public double MaxVolume { get; }

    public int CurrentItemsNumber { get; private set; }
    public double CurrentWeight { get; private set; }
    public double CurrentVolume { get; private set; }

    public bool Add(InventoryItem item)
    {
        if (CurrentItemsNumber >= MaxItemsNumber || CurrentWeight + item.Weight > MaxWeight || CurrentVolume + item.Volume > MaxVolume)
        {
            return false;
        }

        _items.Add(item);

        ++CurrentItemsNumber;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;

        return true;
    }

    public override string ToString()
    {
        var packContentsDescription = _items.Count() > 0 ? string.Join(", ", _items.AsEnumerable()) : "nothing";
        return $"Pack containing {packContentsDescription}.";
    }
}

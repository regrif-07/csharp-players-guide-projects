internal class Pack
{
    private InventoryItem[] _items;

    public Pack(int maxItemsNumber, double maxWeight, double maxVolume)
    {
        if (maxItemsNumber <= 0 || maxWeight <= 0.0 || maxVolume <= 0.0)
        {
            throw new ArgumentException("invalid pack properties");
        }

        _items = new InventoryItem[maxItemsNumber];

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

        _items[CurrentItemsNumber++] = item;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;

        return true;
    }
}

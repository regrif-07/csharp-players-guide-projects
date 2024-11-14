internal class InventoryItem
{
    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }

    public double Weight { get; }
    public double Volume { get; }
}

internal class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }

    public override string ToString() => "Arrow";
}

internal class Bow : InventoryItem
{
    public Bow() : base(1.0, 4.0) { }

    public override string ToString() => "Bow";
}

internal class Rope : InventoryItem
{
    public Rope() : base(1.0, 1.5) { }

    public override string ToString() => "Rope";
}

internal class Water : InventoryItem
{
    public Water() : base(2.0, 3.0) { }

    public override string ToString() => "Water";
}

internal class FoodRation : InventoryItem
{
    public FoodRation() : base(1.0, 0.5) { }

    public override string ToString() => "Food ration";
}

internal class Sword : InventoryItem
{
    public Sword() : base(5.0, 3.0) { }

    public override string ToString() => "Sword";
}

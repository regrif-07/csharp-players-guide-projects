using Utility;

Type[] availableInventoryItemTypes = [typeof(Arrow), typeof(Bow), typeof(Rope), typeof(Water), typeof(FoodRation), typeof(Sword)];

var inventoryItemTypeSelectorMenu = new ConsoleMenuBuilder<Type>()
    .SetTitle("Select the item to add to the pack:")
    .SetItemNameExtractor(item => item.Name.ToSentenceCase())
    .AddItems(availableInventoryItemTypes)
    .Build();

var pack = new Pack(20, 15.0, 17.5);
while (true)
{
    DisplayPackStatus(pack);
    Console.WriteLine($"{pack}\n"); // display pack contents

    var selectedInventoryItemType = inventoryItemTypeSelectorMenu.StartMenuForSelectedItem();
    InventoryItem selectedInventoryItem = Activator.CreateInstance(selectedInventoryItemType) as InventoryItem
        ?? throw new InvalidOperationException("this cast should be supported");

    if (pack.Add(selectedInventoryItem))
    {
        Console.WriteLine($"{selectedInventoryItemType.Name.ToSentenceCase()} was added successfully.");
    }
    else
    {
        Console.WriteLine($"{selectedInventoryItemType.Name.ToSentenceCase()} doesn't fit!");
    }

    Console.WriteLine();
}

void DisplayPackStatus(Pack pack)
{
    Console.WriteLine(
        $"""
        PACK STATUS:
        Items: {pack.CurrentItemsNumber}/{pack.MaxItemsNumber}
        Weight: {pack.CurrentWeight:0.00}/{pack.MaxWeight:0.00}
        Volume: {pack.CurrentVolume:0.00}/{pack.MaxVolume:0.00}
        """);
}
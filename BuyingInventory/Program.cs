using Utility;

Item[] items =
[
    new("Rope", 10),
    new("Torches", 15),
    new("Climbing Equipment", 25),
    new("Clean Water", 1),
    new("Machete", 20),
    new("Canoe", 200),
    new("Food Supplies", 1)
];

var inventoryMenu = new ConsoleMenuBuilder<Item>()
    .SetTitle("The following items are available:")
    .SetItemNameExtractor(item => item.Name)
    .SetNumberNameDelimiter(" - ")
    .SetPrompt("What number do you want to see the price of? ")
    .AddItems(items)
    .Build();

var selectedItem = inventoryMenu.StartMenuForSelectedItem();
Console.WriteLine($"{selectedItem.Name} cost {selectedItem.Price} gold.");

internal record Item(string Name, int Price);

// // simple solution using switch
//Console.WriteLine(
//    """
//    The following items are available:
//    1 – Rope
//    2 – Torches
//    3 – Climbing Equipment
//    4 – Clean Water
//    5 – Machete
//    6 – Canoe
//    7 – Food Supplies
//    """);
//var selectedItemNum = InputUtility.AskUserForValueInRange(1, 7, "What number do you want to see the price of? ");

//var selectedItemName = selectedItemNum switch
//{
//    1 => "Rope",
//    2 => "Torches",
//    3 => "Climbing Equipment",
//    4 => "Clean Water",
//    5 => "Machete",
//    6 => "Canoe",
//    7 => "Food Supplies",
//    _ => throw new NotImplementedException()
//};
//var selectedItemPrice = selectedItemNum switch
//{
//    1 => 10,
//    2 => 15,
//    3 => 25,
//    4 => 1,
//    5 => 20,
//    6 => 200,
//    7 => 1,
//    _ => throw new NotImplementedException()
//};
//Console.WriteLine($"{selectedItemName} cost {selectedItemPrice} gold.");
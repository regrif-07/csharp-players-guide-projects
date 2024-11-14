using Utility;

const string HeroName = "regrif"; // name for discount

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
var finalSelectedItemPrice = (double)selectedItem.Price;

Console.Write("What is your name? ");
var playerName = (Console.ReadLine() ?? "").Trim().ToLower();
if (playerName == HeroName)
{
    finalSelectedItemPrice /= 2.0;
}

Console.WriteLine($"{selectedItem.Name} cost {finalSelectedItemPrice} gold.");

internal record Item(string Name, int Price);
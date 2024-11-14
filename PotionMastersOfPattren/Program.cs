using Utility;

var ingredientSelectionMenu = new ConsoleMenuBuilder<Ingredient>()
    .SetTitle("Select the ingredient to add:")
    .SetItemNameExtractor(ConsoleMenuBuilder<Ingredient>.SentenceCasedItemNameExtractor)
    .AddItems(Enum.GetValues<Ingredient>())
    .Build();

var currentPotion = Potion.Water;
while (true)
{
    Console.WriteLine($"You have a {currentPotion.GetName()}.");

    var ingredientToAdd = ingredientSelectionMenu.StartMenuForSelectedItem();
    currentPotion = currentPotion.AddIngredient(ingredientToAdd);

    if (currentPotion == Potion.Ruined)
    {
        Console.WriteLine("You have ruined your potion!\nLet's start from the beginning...\n");
        currentPotion = Potion.Water;
        continue;
    }

    Console.WriteLine($"You got a {currentPotion.GetName()}!");

    if (!InputUtility.AskUserYesNo("Do you want to continue (y/n)? "))
    {
        break;
    }

    Console.WriteLine();
}
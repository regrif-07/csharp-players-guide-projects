using Utility;

(SoupType Type, Ingredient MainIngredient, Seasoning Seasoning) soup;

soup.Type = new ConsoleMenuBuilder<SoupType>()
    .SetTitle("Select the soup type:")
    .AddItems(Enum.GetValues<SoupType>())
    .Build()
    .StartMenuForSelectedItem();
Console.WriteLine();

soup.MainIngredient = new ConsoleMenuBuilder<Ingredient>()
    .SetTitle("Select the soup's main ingredient:")
    .AddItems(Enum.GetValues<Ingredient>())
    .Build()
    .StartMenuForSelectedItem();
Console.WriteLine();

soup.Seasoning = new ConsoleMenuBuilder<Seasoning>()
    .SetTitle("Select the soup's seasoning:")
    .AddItems(Enum.GetValues<Seasoning>())
    .Build()
    .StartMenuForSelectedItem();
Console.WriteLine();

Console.WriteLine($"Your soup is: {soup.Seasoning} {soup.MainIngredient} {soup.Type}");
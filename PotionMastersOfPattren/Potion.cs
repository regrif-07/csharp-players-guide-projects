using Utility;

internal enum Potion
{
    Water,
    Elexir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined,
}

internal static class PotionExtensions
{
    public static string GetName(this Potion potion) => $"{potion.ToString().ToSentenceCase()} Potion";

    public static Potion AddIngredient(this Potion potion, Ingredient ingredient) => (potion, ingredient) switch
    {
        (Potion.Water,        Ingredient.Stardust    ) => Potion.Elexir,
        (Potion.Elexir,       Ingredient.SnakeVenom  ) => Potion.Poison,
        (Potion.Elexir,       Ingredient.DragonBreath) => Potion.Flying,
        (Potion.Elexir,       Ingredient.ShadowGlass ) => Potion.Invisibility,
        (Potion.Elexir,       Ingredient.EyeshineGem ) => Potion.NightSight,
        (Potion.NightSight,   Ingredient.ShadowGlass ) => Potion.CloudyBrew,
        (Potion.Invisibility, Ingredient.EyeshineGem ) => Potion.CloudyBrew,
        (Potion.CloudyBrew,   Ingredient.Stardust    ) => Potion.Wraith,
        _                                              => Potion.Ruined,
    };
}
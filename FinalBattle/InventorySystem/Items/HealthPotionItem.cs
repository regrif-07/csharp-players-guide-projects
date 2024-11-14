using FinalBattle.Characters;

namespace FinalBattle.InventorySystem.Items;

internal class HealthPotionItem : IInventoryItem
{
    public const int HpRestore = 10;

    public string Name { get; } = "HEALTH POTION";

    public void Use(Character target, Game _)
    {
        target.CurrentHp += HpRestore;
    }
}

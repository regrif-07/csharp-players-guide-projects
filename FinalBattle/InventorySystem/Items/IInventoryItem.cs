using FinalBattle.Characters;

namespace FinalBattle.InventorySystem.Items;

internal interface IInventoryItem
{
    public string Name { get; }

    public void Use(Character target, Game game);
}

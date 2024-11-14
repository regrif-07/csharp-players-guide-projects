using FinalBattle.Attacks;
using FinalBattle.Characters;

namespace FinalBattle.InventorySystem.Items;

internal class Gear : IInventoryItem
{
    public Gear(string name, Attack attack)
    {
        Name = name;
        Attack = attack;
    }

    public string Name { get; }
    public Attack Attack { get; }

    public void Use(Character target, Game game)
    {
        if (target.Gear != null)
        {
            var targetParty = game.CurrentParty.Characters.Contains(target) ? game.CurrentParty : game.OppositeParty;
            targetParty.Inventory.AddItems(target.Gear);
            target.Gear = null;
        }

        target.Gear = this;
    }
}

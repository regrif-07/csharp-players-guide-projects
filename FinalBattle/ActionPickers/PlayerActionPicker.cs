using FinalBattle.Actions;
using FinalBattle.Characters;
using Utility;

namespace FinalBattle.ActionPickers;

internal class PlayerActionPicker : IActionPicker
{
    private readonly ConsoleMenu<PlayerActionOption> _actionOptionSelectionMenu = new ConsoleMenuBuilder<PlayerActionOption>()
        .SetTitle(null)
        .SetNumberNameDelimiter(" - ")
        .SetPrompt("What do you want to do? ")
        .SetItemNameExtractor(ConsoleMenuBuilder<PlayerActionOption>.SentenceCasedItemNameExtractor)
        .AddItems(Enum.GetValues<PlayerActionOption>())
        .Build();

    private enum PlayerActionOption
    {
        Attack,
        SpecialGearAttack,
        UseItem,
        DoNothing,
    }

    public IAction Pick(Character performer, Game game)
    {
        var randomAttackTarget = game.OppositeParty.Characters[Random.Shared.Next(game.OppositeParty.Characters.Count)];

        while (true)
        {
            switch (_actionOptionSelectionMenu.StartMenuForSelectedItem())
            {
                case PlayerActionOption.Attack:
                    return new AttackAction(performer, performer.StandardAttack, randomAttackTarget);

                case PlayerActionOption.SpecialGearAttack:
                    if (performer.Gear == null)
                    {
                        Console.WriteLine("You don't have any gear equipped!");
                        continue;
                    }

                    return new AttackAction(performer, performer.Gear.Attack, randomAttackTarget);

                case PlayerActionOption.UseItem:
                    var currentPartyInventory = game.CurrentParty.Inventory;

                    if (currentPartyInventory.IsEmpty)
                    {
                        Console.WriteLine("You inventory is empty!");
                        continue;
                    }

                    var itemIndexSelectionMenu = game.CurrentParty.Inventory.BuildItemIndexSelectionMenu();
                    var selectedItemIndex = itemIndexSelectionMenu.StartMenuForSelectedItem();
                    var selectedItem = game.CurrentParty.Inventory.GrabItemByIndex(selectedItemIndex)!;

                    return new UseItemAction(game, performer, selectedItem, performer);

                case PlayerActionOption.DoNothing:
                    return new DoNothingAction(performer);

                default:
                    throw new InvalidOperationException("unhandled player action option");
            }
        }
    }
}

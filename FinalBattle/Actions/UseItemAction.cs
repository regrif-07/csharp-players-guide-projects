using FinalBattle.Characters;
using FinalBattle.InventorySystem.Items;
using System.Xml.Linq;

namespace FinalBattle.Actions;

internal class UseItemAction : IAction
{
    private readonly Game _game;

    private readonly Character _performer;
    private readonly IInventoryItem _item;
    private readonly Character _target;

    public UseItemAction(Game game, Character performer, IInventoryItem item, Character target)
    {
        _game = game;

        _performer = performer;
        _item = item;
        _target = target;
    }

    public void Perform()
    {
        _item.Use(_target, _game);

        if (_item is Gear)
        {
            Console.WriteLine($"{_item.Name} was equipped on {_target.Name}.");
        }
        else
        {
            var targetName = (_performer == _target) ? "himself" : _target.Name;
            Console.WriteLine($"{_performer.Name} used {_item.Name} on {targetName}.");
        }
    }
}

using FinalBattle.Actions;
using FinalBattle.Characters;

namespace FinalBattle.ActionPickers;

internal interface IActionPicker
{
    public IAction Pick(Character performer, Game game);
}

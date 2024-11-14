using FinalBattle.Attacks;
using FinalBattle.Characters;
using Utility;

namespace FinalBattle.Actions;

internal class AttackAction : IAction
{
    private readonly Character _performer;
    private readonly Attack _attack;
    private readonly Character _target;

    public AttackAction(Character performer, Attack attack, Character target)
    {
        _performer = performer;
        _attack = attack;
        _target = target;
    }

    public void Perform()
    {
        Console.WriteLine($"{_performer.Name} used {_attack.Name} on {_target.Name}.");   

        var attackData = _attack.ProduceAttackData();
        if (_target.DefensiveAttackModifier != null )
        {
            _target.DefensiveAttackModifier.Modify(attackData);
        }

        if (!Random.Shared.CoinFlip(attackData.HitChanceFraction))
        {
            Console.WriteLine($"{_performer.Name} missed!");
            return;
        }
        _target.CurrentHp -= attackData.Damage;

        Console.WriteLine($"{_attack.Name} dealt {attackData.Damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.CurrentHp}/{_target.MaxHp} HP.");
    }
}

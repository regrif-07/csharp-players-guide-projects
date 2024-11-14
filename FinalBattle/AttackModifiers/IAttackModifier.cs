using FinalBattle.Attacks;

namespace FinalBattle.AttackModifiers;

internal interface IAttackModifier
{
    public string Name { get; }

    public void Modify(AttackData attackData);
}

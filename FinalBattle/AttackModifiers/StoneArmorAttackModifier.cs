using FinalBattle.Attacks;

namespace FinalBattle.AttackModifiers;

internal class StoneArmorAttackModifier : IAttackModifier
{
    private int _damageReductionAmount;

    public StoneArmorAttackModifier(int damageReductionAmount = 1)
    {
        _damageReductionAmount = damageReductionAmount;
    }

    public string Name { get; } = "STONE ARMOR";

    public void Modify(AttackData attackData)
    {
        attackData.Damage -= _damageReductionAmount;
        Console.WriteLine($"{Name} reduced the attack by {_damageReductionAmount}.");
    }
}

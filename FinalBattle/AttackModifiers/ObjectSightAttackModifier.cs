using FinalBattle.Attacks;

namespace FinalBattle.AttackModifiers;

internal class ObjectSightAttackModifier : IAttackModifier
{
    private int _damageReductionAmount;

    public ObjectSightAttackModifier(int damageReductionAmount = 2)
    {
        _damageReductionAmount = damageReductionAmount;
    }

    public string Name { get; } = "OBJECT SIGHT";

    public void Modify(AttackData attackData)
    {
        if (attackData.DamageType == DamageType.Decoding)
        {
            attackData.Damage -= _damageReductionAmount;
            Console.WriteLine($"{Name} reduced the decoding attack {attackData.AttackName} by {_damageReductionAmount}.");
        }
    }
}

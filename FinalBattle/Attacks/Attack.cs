namespace FinalBattle.Attacks;

internal class Attack
{
    private readonly Func<int> _damageGenerator;
    private double _hitChanceFraction;
    private DamageType _damageType;

    public Attack(string name, Func<int> damageGenerator, double hitChanceFraction = 1.0, DamageType damageType = DamageType.Normal)
    {
        Name = name;
        _damageGenerator = damageGenerator;
        _hitChanceFraction = hitChanceFraction;
        _damageType = damageType;
    }

    public string Name { get; }

    public AttackData ProduceAttackData() => new AttackData(Name, _damageGenerator(), _hitChanceFraction, _damageType);
}

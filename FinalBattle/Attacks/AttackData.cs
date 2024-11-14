namespace FinalBattle.Attacks;

internal class AttackData
{
    private int _damage;

    public AttackData(string name, int damage, double hitChanceFraction, DamageType damageType)
    {
        AttackName = name;
        _damage = damage;
        HitChanceFraction = hitChanceFraction;
        DamageType = damageType;
    }

    public string AttackName { get; }
    public int Damage { get => _damage; set => _damage = Math.Clamp(_damage, 0, int.MaxValue); }
    public double HitChanceFraction { get; set; }
    public DamageType DamageType { get; }
}
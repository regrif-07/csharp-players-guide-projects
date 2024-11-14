using FinalBattle.AttackModifiers;
using FinalBattle.Attacks;
using FinalBattle.InventorySystem.Items;

namespace FinalBattle.Characters;

internal class Character
{
    private int _currentHp;

    public Character(string name, int maxHp, Attack standardAttack, Gear? gear = null, IAttackModifier? defensiveAttackModifer = null)
    {
        Name = name;
        MaxHp = maxHp;
        StandardAttack = standardAttack;
        Gear = gear;
        DefensiveAttackModifier = defensiveAttackModifer;

        _currentHp = MaxHp;
    }

    public string Name { get; }
    public int MaxHp { get; }
    public int CurrentHp
    {
        get => _currentHp;
        set => _currentHp = Math.Clamp(value, 0, MaxHp);
    }
    public Attack StandardAttack { get; }
    public Gear? Gear { get; set; }
    public IAttackModifier? DefensiveAttackModifier { get; }

    public bool IsDead => _currentHp <= 0;
}

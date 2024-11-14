namespace FinalBattle.Attacks;

internal static class AttackPresets
{
    public static readonly Attack Punch = new("PUNCH", () => 1);
    public static readonly Attack BoneCrunch = new("BONE CRUNCH", () => Random.Shared.Next(2));
    public static readonly Attack Unraveling = new("UNRAVELING", () => Random.Shared.Next(4), 1.0, DamageType.Decoding);
    public static readonly Attack Slash = new("SLASH", () => 2);
    public static readonly Attack Stab = new("STAB", () => 1);
    public static readonly Attack Quickshot = new("QUICKSHOT", () => 3, 0.5);
    public static readonly Attack Bite = new("BITE", () => 1);
}

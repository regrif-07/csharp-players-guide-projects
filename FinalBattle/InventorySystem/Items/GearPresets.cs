using FinalBattle.Attacks;

namespace FinalBattle.InventorySystem.Items;

internal static class GearPresets
{
    public static readonly Gear Sword = new("SWORD", AttackPresets.Slash);
    public static readonly Gear Dagger = new("DAGGER", AttackPresets.Stab);
    public static readonly Gear VinsBow = new("VIN'S BOW", AttackPresets.Quickshot);
}

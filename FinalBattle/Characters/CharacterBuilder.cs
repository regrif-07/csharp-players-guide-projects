using FinalBattle.AttackModifiers;
using FinalBattle.Attacks;
using FinalBattle.InventorySystem.Items;

namespace FinalBattle.Characters;

internal static class CharacterBuilder
{
    private static int _skeletonCounter = 0;

    public static Character BuildTrueProgrammer(string? name, Gear? gear = null) => new Character(
        string.IsNullOrEmpty(name) ? "TRUE PROGRAMMER" : name,
        25,
        AttackPresets.Punch,
        gear,
        new ObjectSightAttackModifier());

    public static Character BuildSkeleton(Gear? gear = null) => new Character(
        $"SKELETON #{++_skeletonCounter}",
        5,
        AttackPresets.BoneCrunch,
        gear);

    public static Character BuildUncodedOne(Gear? gear = null) => new Character(
        "THE UNCODED ONE",
        15,
        AttackPresets.Unraveling,
        gear);

    public static Character BuildVinFletcher(Gear? gear = null) => new Character(
        "VIN FLETCHER",
        15,
        AttackPresets.Punch,
        gear);

    public static Character BuildStoneAmarok(Gear? gear = null) => new Character(
        "STONE AMAROK",
        4,
        AttackPresets.Bite,
        gear,
        new StoneArmorAttackModifier());
}

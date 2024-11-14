namespace FountainOfObjects.CavernComponents;

internal static class CavernPresetsBuilder
{
    public static Cavern BuildSmallCavernPreset() => CavernStringBuilder.Build(
        "0AF0" +
        "00P0" +
        "P000" +
        "0E00",
        4, 4);

    public static Cavern BuildMediumCavernPreset() => CavernStringBuilder.Build(
        "0000A0" +
        "0000PF" +
        "00A000" +
        "00M0PP" +
        "000000" +
        "0E00P0",
        6, 6);

    public static Cavern BuildLargeCavernBuilder() => CavernStringBuilder.Build(
        "000A000P" +
        "000P0P00" +
        "000PFP0P" +
        "P00PPP00" +
        "00M000A0" +
        "0000P000" +
        "00P00000" +
        "0000P0E0",
        8, 8);
}

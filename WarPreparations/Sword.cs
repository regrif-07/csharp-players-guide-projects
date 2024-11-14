internal record Sword(SwordMaterial Material, SwordGemstone Gemstone, double LengthCm, double CrossguardWidthCm);

internal enum SwordMaterial
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium,
}

internal enum SwordGemstone
{
    NoGemstone,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone,
}
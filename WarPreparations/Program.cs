var longsword = new Sword(SwordMaterial.Iron, SwordGemstone.NoGemstone, 100.0, 25.0);
var greatsword = longsword with { LengthCm = 150.0, CrossguardWidthCm = 30.0 };
var legendaryGreatsword = greatsword with { Material = SwordMaterial.Binarium, Gemstone = SwordGemstone.Bitstone };

Console.WriteLine(longsword);
Console.WriteLine(greatsword);
Console.WriteLine(legendaryGreatsword);

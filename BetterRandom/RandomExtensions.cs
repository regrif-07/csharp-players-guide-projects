internal static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) => random.NextDouble() * max;
    public static string NextString(this Random random, params string[] strings) => strings[random.Next(strings.Length)];
    public static bool CoinFlip(this Random random, double headsFrequency = 0.5) => random.NextDouble() <= headsFrequency;
}
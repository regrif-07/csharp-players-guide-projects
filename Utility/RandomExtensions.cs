namespace Utility;

public static class RandomExtensions
{
    public static bool CoinFlip(this Random random, double chanceFraction = 0.5) => random.NextDouble() <= chanceFraction;
}

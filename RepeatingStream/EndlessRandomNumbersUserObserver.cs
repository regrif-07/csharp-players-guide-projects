internal class EndlessRandomNumbersUserObserver
{
    public void StartObservation(object? recentNumbersObject)
    {
        var recentNumbers = (RecentNumbers)recentNumbersObject!;

        while (true)
        {
            Console.ReadKey(true);

            if (AreRecentNumbersSame(recentNumbers))
            {
                Console.WriteLine("You successfully identified the repeat!");
            }
            else
            {
                Console.WriteLine("That's not a repeat... Try again.");
            }
        }
    }

    bool AreRecentNumbersSame(RecentNumbers recentNumbers)
    {
        // if the last two numbers are not generated yet, return false
        if (!recentNumbers.LastNumber.HasValue || !recentNumbers.PenultimateNumber.HasValue)
        {
            return false;
        }

        return recentNumbers.LastNumber.Value == recentNumbers.PenultimateNumber.Value;
    }
}

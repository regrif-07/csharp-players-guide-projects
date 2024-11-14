internal class EndlessRandomNumbersGenerator
{
    private int _minRandomNumber;
    private int _maxRandomNumber;
    private int _delayMilliseconds; // delay between random number generation in milliseconds

    public EndlessRandomNumbersGenerator(int minRandomNumber, int maxRandomNumber, int delayMilliseconds)
    {
        if (minRandomNumber > maxRandomNumber)
        {
            throw new ArgumentException("min random number cannot be greater than max random number");
        }

        _minRandomNumber = minRandomNumber;
        _maxRandomNumber = maxRandomNumber;
        _delayMilliseconds = delayMilliseconds;
    }

    public void StartGeneration(object? recentNumbersObject)
    {
        var recentNumbers = (RecentNumbers)recentNumbersObject!;

        while (true)
        {
            var newRandomNumber = Random.Shared.Next(_minRandomNumber, _maxRandomNumber + 1);

            recentNumbers.LastNumber = newRandomNumber;
            Console.WriteLine(newRandomNumber);

            Thread.Sleep(_delayMilliseconds);
        }
    }
}

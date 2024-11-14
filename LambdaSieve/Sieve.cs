internal class Sieve
{
    private readonly Predicate<int> _predicate;

    public Sieve(Predicate<int> predicate)
    {
        _predicate = predicate;
    }

    public bool IsGood(int number) => _predicate(number);
}

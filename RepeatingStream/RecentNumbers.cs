internal class RecentNumbers
{
    private object _recentNumbersLock = new object();

    private int? _lastNumber = null;
    private int? _penultimateNumber = null;

    public int? LastNumber 
    {
        get
        { 
            lock (_recentNumbersLock)
            {
                return _lastNumber;
            }
        }

        set
        {
            lock (_recentNumbersLock)
            {
                _penultimateNumber = _lastNumber;
                _lastNumber = value;
            }
        }
    }

    public int? PenultimateNumber
    {
        get
        {
            lock (_recentNumbersLock)
            {
                return _penultimateNumber;
            }
        }
    }
}
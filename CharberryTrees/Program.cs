var charberryTree = new CharberryTree();
var notifier = new Notifier(charberryTree);
var harvester = new Harvester(charberryTree);

while (true)
    charberryTree.MaybeGrow();

internal class CharberryTree
{
    private Random _random = new Random();

    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
    public bool Ripe { get; set; }
}

internal class Notifier : IDisposable
{
    private readonly CharberryTree _charberryTree;

    public Notifier(CharberryTree charberryTree)
    {
        _charberryTree = charberryTree;

        _charberryTree.Ripened += Notify;
    }

    public void Dispose()
    {
        _charberryTree.Ripened -= Notify;
    }

    private void Notify()
    {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

internal class Harvester : IDisposable
{
    private readonly CharberryTree _charberryTree;

    public Harvester(CharberryTree charberryTree)
    {
        _charberryTree = charberryTree;

        _charberryTree.Ripened += Harvest;
    }

    public void Dispose()
    {
        _charberryTree.Ripened -= Harvest;
    }

    private void Harvest()
    {
        _charberryTree.Ripe = false;
    }
}
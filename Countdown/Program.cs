Countdown(10, 1);

void Countdown(int from, int to)
{
    Console.WriteLine(from);

    if (from == to)
    {
        return;
    }

    Countdown(from - 1, to);
}
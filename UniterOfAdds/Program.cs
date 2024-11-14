Console.WriteLine(Adds.Add(5, 6));
Console.WriteLine(Adds.Add(10.1, 8.2));
Console.WriteLine(Adds.Add("hello ", "world!"));
Console.WriteLine(Adds.Add(DateTime.Now, TimeSpan.FromDays(7)));

internal static class Adds
{
    public static dynamic Add(dynamic a, dynamic b) => a + b;
}
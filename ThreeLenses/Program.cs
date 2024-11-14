int[] array = [1, 9, 2, 8, 3, 7, 4, 6, 5];

Console.WriteLine(string.Join(", ", ProcessArrayProcedural(array)));
Console.WriteLine(string.Join(", ", ProcessArrayKeywordQueries(array)));
Console.WriteLine(string.Join(", ", ProcessArrayMethodQueries(array)));

IEnumerable<int> ProcessArrayProcedural(int[] array)
{
    var processed = new List<int>();

    foreach (var num in  array)
    {
        if (num % 2 == 0)
        {
            processed.Add(num);
        }
    }

    processed.Sort();

    for (int i = 0; i < processed.Count; ++i)
    {
        processed[i] *= 2;
    }

    return processed;
}

IEnumerable<int> ProcessArrayKeywordQueries(int[] array) => from num in array
                                                            where num % 2 == 0
                                                            orderby num
                                                            select num * 2;

IEnumerable<int> ProcessArrayMethodQueries(int[] array) => array
    .Where(n => n % 2 == 0)
    .Order()
    .Select(n => n * 2);
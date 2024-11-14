using System.Text;
using Utility;

var wordToRecreate = InputUtility.AskUserForValue<string>("Enter the word to recreate: ");

var recreateStartTime = DateTime.Now;

int recreateAttempts;
try
{ 
    recreateAttempts = await RandomlyRecreateAsync(wordToRecreate).ConfigureAwait(false);
}
catch (ArgumentException)
{
    Console.WriteLine("Your input should contain only letters.");
    return;
}

var recreateTimeSeconds = (DateTime.Now - recreateStartTime).Seconds;

Console.WriteLine($"The word was successfully recreated!\nAttemtps: {recreateAttempts}\nTime: {recreateTimeSeconds} second(s)");

Task<int> RandomlyRecreateAsync(string word) => Task.Run(() => RandomlyRecreate(word));

int RandomlyRecreate(string word)
{
    if (!word.All(char.IsLetter))
    {
        throw new ArgumentException("input string can contain only letters");
    }

    var wordUniform = word.ToLowerInvariant();

    int attempts = 0;
    while (true)
    {
        ++attempts;

        var randomWordSb = new StringBuilder();
        for (int i = 0; i < word.Length; ++i)
        {
            randomWordSb.Append((char)('a' + Random.Shared.Next(26)));
        }

        var randomWord = randomWordSb.ToString();
        if (randomWord == wordUniform)
        {
            return attempts;
        }
    }
}
using System.Text;
using Utility;

Console.WriteLine("Enter as many words to recreate as you want.");
while (true)
{
    var wordToRecreate = InputUtility.AskUserForValue<string>("> ");
    ProcessRecreationRequest(wordToRecreate);
}

async void ProcessRecreationRequest(string wordToRecreate)
{
    var requestStartTime = DateTime.Now;
    var recreationAttempts = await RandomlyRecreateAsync(wordToRecreate).ConfigureAwait(false);
    var requestTimeSeconds = (DateTime.Now - requestStartTime).TotalSeconds;

    Console.WriteLine($"! \"{wordToRecreate}\" was successfully recreated. " +
        $"Attemtps - {recreationAttempts}. " +
        $"Time - {requestTimeSeconds} second(s).");
}

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
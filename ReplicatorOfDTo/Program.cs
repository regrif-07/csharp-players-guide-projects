using Utility;

const int ArrayLength = 5;

var originalArray = new int[ArrayLength];

Console.WriteLine($"Populate the array of length {originalArray.Length}:");
for (int i = 0; i < originalArray.Length; ++i)
{
    originalArray[i] = InputUtility.AskUserForValue<int>($"{i + 1}: ");
}

var copyArray = new int[originalArray.Length];
for (int i = 0; i < copyArray.Length; ++i)
{
    copyArray[i] = originalArray[i];
}

Console.WriteLine($"Original array: {string.Join(", ", originalArray)}");
Console.WriteLine($"Copy array: {string.Join(", ", copyArray)}");
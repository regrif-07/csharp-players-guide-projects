using System.Globalization;

namespace Utility;

public static class InputUtility
{
    public static T AskUserForValue<T>(string? prompt = null) where T : IParsable<T>
    {
        while (true)
        {
            if (prompt != null)
            {
                Console.Write(prompt);
            }

            var userInput = Console.ReadLine();
            if (T.TryParse(userInput, CultureInfo.InvariantCulture, out T? userValue) && userValue != null)
            {
                return userValue;
            }

            Console.WriteLine($"Invalid input (\"{userInput}\"). Try again.");
        }
    }

    public static T AskUserForValueInRange<T>(T minValue, T maxValue, string? prompt = null) where T : IParsable<T>, IComparable<T>
    {
        while (true)
        {
            var userValue = AskUserForValue<T>(prompt);

            if (userValue.CompareTo(minValue) >= 0 && userValue.CompareTo(maxValue) <= 0)
            {
                return userValue;
            }

            Console.WriteLine($"Entered value should be in the range from {minValue} to {maxValue}.");
        }
    }

    public static bool AskUserYesNo(string? prompt = null)
    {
        while (true)
        {
            if (prompt != null)
            {
                Console.Write(prompt);
            }

            switch (Console.ReadLine()?.Trim().ToLower() ?? "")
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                    return false;
                default:
                    Console.WriteLine("You should answer either yes or no.");
                    continue;
            }
        }
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}

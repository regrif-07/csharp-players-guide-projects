using Utility;

// using Utility class library
var userInt = InputUtility.AskUserForValue<int>("Enter an integer: ");
var userDouble = InputUtility.AskUserForValue<double>("Enter a double: ");
var userBool = InputUtility.AskUserForValue<bool>("Enter a boolean: ");

Console.WriteLine($"\nYour int: {userInt}");
Console.WriteLine($"Your double: {userDouble}");
Console.WriteLine($"Your boolean: {userBool}");
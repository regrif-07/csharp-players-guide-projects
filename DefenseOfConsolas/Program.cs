using Utility;

Console.Title = "Defense of Consolas";

var targetRow = InputUtility.AskUserForValue<int>("Target Row? ");
var targetColumn = InputUtility.AskUserForValue<int>("Target Column? ");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Deploy to:");
Console.WriteLine($"({targetRow}, {targetColumn - 1})");
Console.WriteLine($"({targetRow - 1}, {targetColumn})");
Console.WriteLine($"({targetRow}, {targetColumn + 1})");
Console.WriteLine($"({targetRow + 1}, {targetColumn})");
Console.ResetColor();

Console.Beep(440, 1000);
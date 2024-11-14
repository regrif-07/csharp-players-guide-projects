using Utility;

const string ExitCommand = "exit";

var passwordValidator = new PasswordValidator
{
    MinLength = 6,
    MaxLength = 13,
    MinUppercaseLetters = 1,
    MinLowercaseLetters = 1,
    MinDigits = 1,
    ForbiddenChars = ['T', '&'],
};
passwordValidator.DisplayPasswordRequirements();

Console.WriteLine($"\nType \"{ExitCommand}\" to stop the validation loop.");

while (true)
{
    Console.Write("\nEnter the password to validate: ");
    var userInput = Console.ReadLine();
    if (userInput == null)
    {
        Console.WriteLine("Invalid input. Try again.");
        continue;
    }

    if (userInput.Trim().ToLower() == ExitCommand)
    {
        break;
    }

    if (passwordValidator.Validate(userInput))
    {
        OutputUtility.WriteLineColored("The password is VALID.", ConsoleColor.Green);
    }
    else
    {
        OutputUtility.WriteLineColored("The password is INVALID.", ConsoleColor.Red);
    }
}

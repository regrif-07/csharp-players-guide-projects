internal class PasswordValidator
{
    public uint MinLength { get; init; } = 0;
    public uint MaxLength { get; init; } = 0; // 0 = no max length
    public uint MinUppercaseLetters { get; init; } = 0;
    public uint MinLowercaseLetters { get; init; } = 0;
    public uint MinDigits { get; init; } = 0;
    public char[] ForbiddenChars { get; init; } = [];

    public void DisplayPasswordRequirements()
    {
        var passwordRequirementMessages = new List<string>();
        if (MinLength != 0)
        {
            passwordRequirementMessages.Add($"- Have a minimum length of {MinLength}.");
        }
        if (MaxLength != 0)
        {
            passwordRequirementMessages.Add($"- Have a maximum length of {MaxLength}.");
        }
        if (MinUppercaseLetters != 0)
        {
            passwordRequirementMessages.Add($"- Contain at least {MinUppercaseLetters} uppercase letter(s).");
        }
        if (MinLowercaseLetters != 0)
        {
            passwordRequirementMessages.Add($"- Contain at least {MinLowercaseLetters} lowercase letter(s).");
        }
        if (MinDigits != 0)
        {
            passwordRequirementMessages.Add($"- Contain at least {MinDigits} digit(s).");
        }
        if (ForbiddenChars.Length != 0)
        {
            passwordRequirementMessages.Add($"- Not contain any of the following symbol(s): {string.Join(", ", ForbiddenChars)}.");
        }

        if (passwordRequirementMessages.Count == 0)
        {
            Console.WriteLine("Your password doesn't have any requirements.");
        }
        else
        {
            Console.WriteLine("Your password should:");
            foreach (var message in passwordRequirementMessages)
            {
                Console.WriteLine(message);
            }
        }
    }

    public bool Validate(string password) =>
        password.Length >= MinLength &&
        (MaxLength == 0 || password.Length <= MaxLength) &&
        password.Count(char.IsUpper) >= MinUppercaseLetters &&
        password.Count(char.IsLower) >= MinLowercaseLetters &&
        password.Count(char.IsDigit) >= MinDigits &&
        password.All(c => !ForbiddenChars.Contains(c));
}
var intitialDoorPasscode = AskUserForPasscode("Enter the door's initial passcode: ");

var door = new Door(intitialDoorPasscode);
while (true)
{
    Console.WriteLine();

    door.DisplayStatus();

    Console.Write("Enter the command to perform: ");
    bool commandStatus = Console.ReadLine()?.Trim().ToLower() switch
    {
        "close"  => door.Close(),
        "open"   => door.Open(),
        "lock"   => door.Lock(),
        "unlock" => door.Unlock(AskUserForPasscode("Enter the passcode: ")),

        "change" or "passcode" or "change passcode" =>
            door.ChangePasscode(AskUserForPasscode("Enter the old passcode: "), AskUserForPasscode("Enter the new passcode: ")),

        _ => false,
    };

    if (!commandStatus)
    {
        Console.WriteLine("Invalid command/command execution failed.");
    }
}

string AskUserForPasscode(string? prompt = null)
{
    while (true)
    {
        if (prompt != null)
        {
            Console.Write(prompt);
        }

        var userPasscode = Console.ReadLine();
        if (string.IsNullOrEmpty(userPasscode))
        {
            Console.WriteLine("Passcode cannot be empty. Try again.");
            continue;
        }

        return userPasscode;
    }
}
var robot = new Robot();

var commandsNum = robot.Commands.Count();
Console.WriteLine($"Input {commandsNum} command(s):");
for (int commandIndex = 0; commandIndex < commandsNum; ++commandIndex)
{
    robot.Commands[commandIndex] = AskUserForRobotCommand();
}

robot.Run();

IRobotCommand AskUserForRobotCommand()
{
    while (true)
    {
        Console.Write("Enter a robot command: ");

        var userRobotCommand = Console.ReadLine()?.Trim().ToLower() ?? "";
        switch (userRobotCommand)
        {
            case "on":    return new OnCommand();
            case "off":   return new OffCommand();
            case "north": return new NorthCommand();
            case "south": return new SouthCommand();
            case "west":  return new WestCommand();
            case "east":  return new EastCommand();
            default:
                Console.WriteLine("Unknown command. Try again.");
                continue;
        }
    }
}
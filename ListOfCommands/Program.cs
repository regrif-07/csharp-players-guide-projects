var robot = new Robot();
FillRobotWithUserCommands(robot);
robot.Run();

void FillRobotWithUserCommands(Robot robot)
{
    Console.WriteLine($"Input robot commands. When you are done, type \"stop\".");
    while (true)
    {
        Console.Write("> ");
        var userInput = Console.ReadLine();
        var robotCommand = GetRobotCommandByName(userInput);

        if (robotCommand != null)
        {
            robot.Commands.Add(robotCommand);
        }
        else if (userInput == "stop")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid command. Try again.");
        }
    }
}

IRobotCommand? GetRobotCommandByName(string? robotCommandName) =>
    (robotCommandName?.Trim().ToLower() ?? "") switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        _ => null
    };
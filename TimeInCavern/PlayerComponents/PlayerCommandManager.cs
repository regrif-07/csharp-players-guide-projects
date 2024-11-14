
using FountainOfObjects.Rooms;

namespace FountainOfObjects.PlayerComponents;

internal class PlayerCommandManager
{
    private readonly Game _game;

    public PlayerCommandManager(Game game)
    {
        _game = game;
    }

    public void StartPlayerTurn()
    {
        while (true)
        {
            Console.Write("What do you want to do? ");
            if (ProcessCommand(Console.ReadLine()?.Trim().ToLower() ?? ""))
            {
                break;
            }
        }
    }

    private bool ProcessCommand(string playerCommand)
    {
        var playerCommandUniform = playerCommand.Trim().ToLower();

        if (playerCommandUniform.StartsWith("move") && playerCommandUniform.Length > 4)
        {
            return ProcessMoveCommand(playerCommandUniform.Substring(4));
        }
        if (playerCommand.StartsWith("shoot") && playerCommand.Length > 5)
        {
            return ProcessShootCommand(playerCommandUniform.Substring(5));
        }
        if (playerCommandUniform == "enable fountain")
        {
            return ProcessEnableFountainCommand();
        }
        if (playerCommandUniform == "help")
        {
            return ProcessHelpCommand();
        }

        Console.WriteLine("Invalid command. Use the \"help\" command for more info.");
        return false;
    }

    private bool ProcessMoveCommand(string directionName)
    {
        RoomPosition targetRoomPosition;
        try
        {
            targetRoomPosition = _game.Player.Position.AddByDirectionName(directionName);
        } 
        catch (ArgumentException)
        {
            Console.WriteLine("Unknown move direction.");
            return false;
        }

        if (!_game.Cavern.IsValidRoomPosition(targetRoomPosition))
        {
            Console.WriteLine("There is a wall there.");
            return false;
        }

        _game.Player.Position = targetRoomPosition;

        return true;
    }

    private bool ProcessShootCommand(string directionName)
    {
        if (_game.Player.ArrowsLeft <= 0)
        {
            Console.WriteLine("You don't have any arrows to shoot!");
            return false;
        }

        RoomPosition targetRoomPosition;
        try
        {
            targetRoomPosition = _game.Player.Position.AddByDirectionName(directionName);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Unknown shoot direction.");
            return false;
        }

        if (!_game.Cavern.IsValidRoomPosition(targetRoomPosition))
        {
            Console.WriteLine("Shooting at the wall is a bad idea.");
            return false;
        }

        --_game.Player.ArrowsLeft;
        Console.Write("You shot an arrow... ");
        switch (_game.Cavern.GetRoomAt(targetRoomPosition))
        {
            case MaelstromRoom:
            case AmarokRoom:
                Console.WriteLine("And it hit someone!");
                _game.Cavern.SetRoomAt(targetRoomPosition, new EmptyRoom());
                break;

            default:
                Console.WriteLine("And it just hit the wall...");
                break;
        }

        return true;
    }

    private bool ProcessEnableFountainCommand()
    {
        if (_game.Player.Position != _game.Cavern.FountainRoomPosition)
        {
            Console.WriteLine("You are not in a fountain room.");
            return false;
        }
        if (_game.Cavern.FountainRoom.IsFountainActive)
        {
            Console.WriteLine("The fountain is already active!");
            return false;
        }

        _game.Cavern.FountainRoom.IsFountainActive = true;
        Console.WriteLine("Fountain is now active!");
        return true;
    }

    private bool ProcessHelpCommand()
    {
        Console.WriteLine(
            """
            Available commands:
            - move <direction>: Moves the player in the specified direction (north, south, east, west).
            - shoot <direction>: Shoots an arrow in the specified direction (north, south, east, west).
            - enable fountain: Enables the fountain if the player is in the fountain room.
            - help: Displays this help message.

            Examples:
            - move north
            - shoot east
            - enable fountain
            - help
            """);

        return false;
    }
}

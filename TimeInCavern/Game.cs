using FountainOfObjects.CavernComponents;
using FountainOfObjects.PlayerComponents;

namespace FountainOfObjects;

internal class Game
{
    private const int PlayerInitialArrowsNumber = 5;

    private readonly PlayerCommandManager _playerCommandManager;
    private bool _gameLoopResetRequested = false;

    public Game(Cavern cavern)
    {
        Cavern = cavern;

        Player = new Player(cavern.EntranceRoomPosition, PlayerInitialArrowsNumber);
        _playerCommandManager = new PlayerCommandManager(this);
    }

    public Cavern Cavern { get; }
    public Player Player { get; }

    public bool InProcess { get; set; } = true;


    // returns true if the player ended with player being alive (victory), false otherwise (defeat)
    public bool Start()
    {
        while (true)
        {
            DisplayDelimiter();

            DisplayPlayerStatus();

            UpdateCurrentPlayerRoom();
            if (_gameLoopResetRequested)
            {
                _gameLoopResetRequested = false;
                continue;
            }
            if (!InProcess)
            {
                return Player.IsAlive;
            }

            UpdateAdjacentPlayerRooms();

            _playerCommandManager.StartPlayerTurn();
        }
    }

    public void RequestGameLoopReset() => _gameLoopResetRequested = true;

    private void DisplayDelimiter() => Console.WriteLine("----------------------------------------------------------------------------------");

    private void DisplayPlayerStatus()
    {
        Console.WriteLine($"You are in the room at {Player.Position}.");

        if (Player.ArrowsLeft > 0)
        {
            Console.WriteLine($"You have {Player.ArrowsLeft} arrows left.");
        }
        else
        {
            Console.WriteLine("You don't have any arrows.");
        }
    }

    private void UpdateCurrentPlayerRoom()
    {
        Cavern.GetRoomAt(Player.Position).OnPlayerInside(this);
    }

    private void UpdateAdjacentPlayerRooms()
    {
        var playerAdjacentRoomsPositions = Player.Position.GetAdjacentRoomsCoordinates().Where(Cavern.IsValidRoomPosition).ToList();
        foreach (var playerAdjacentRoomPosition in playerAdjacentRoomsPositions)
        {
            Cavern.GetRoomAt(playerAdjacentRoomPosition).OnPlayerNearby(this);
        }
    }
}

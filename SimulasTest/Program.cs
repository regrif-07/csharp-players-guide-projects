using Utility;

var currentChestState = ChestState.Locked;
while (true)
{
    Console.Write($"The chest is {currentChestState.ToString().ToLower()}. What do you want to do? ");

    var userChestAction = EnumUtility.DeduceEnumFromString<ChestAction>(Console.ReadLine());
    if (userChestAction == null)
    {
        Console.WriteLine("Unknown chest action. Available options are: open, close, unlock, lock.");
        continue;
    }

    currentChestState = ApplyChestAction(currentChestState, (ChestAction)userChestAction);
}

ChestState ApplyChestAction(ChestState currentState, ChestAction action) => (currentState, action) switch
{
    (ChestState.Open, ChestAction.Close) => ChestState.Closed,
    (ChestState.Closed, ChestAction.Open) => ChestState.Open,
    (ChestState.Closed, ChestAction.Lock) => ChestState.Locked,
    (ChestState.Locked, ChestAction.Unlock) => ChestState.Closed,
    _ => currentState // unavailable operation, state doesn't change
};

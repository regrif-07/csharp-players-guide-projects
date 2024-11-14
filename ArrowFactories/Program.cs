using Utility;

var userSelectedArrowOption = new ConsoleMenuBuilder<UserArrowOption>()
    .SetTitle("Selecte the type of the arrow:")
    .AddItems(Enum.GetValues<UserArrowOption>())
    .Build()
    .StartMenuForSelectedItem();

var userArrow = userSelectedArrowOption switch
{
    UserArrowOption.Elite => Arrow.CreateEliteArrow(),
    UserArrowOption.Beginner => Arrow.CreateBeginnerArrow(),
    UserArrowOption.Marksman => Arrow.CreateMarksmanArrow(),
    UserArrowOption.Custom => AskUserForCustomArrow(),
    _ => throw new NotImplementedException()
};

Console.WriteLine($"\nThe cost of your arrow is {userArrow.GetCost():0.00} gold.");

Arrow AskUserForCustomArrow()
{
    var userArrowArrowheadType = new ConsoleMenuBuilder<ArrowheadType>()
        .SetTitle("\nSelect the arrowhead type:")
        .SetItemNameExtractor(ConsoleMenuBuilder<ArrowheadType>.SentenceCasedItemNameExtractor)
        .AddItems(Enum.GetValues<ArrowheadType>())
        .Build()
        .StartMenuForSelectedItem();
    Console.WriteLine();

    var userArrowFletchingType = new ConsoleMenuBuilder<FletchingType>()
        .SetTitle("Select the fletching type:")
        .SetItemNameExtractor(ConsoleMenuBuilder<FletchingType>.SentenceCasedItemNameExtractor)
        .AddItems(Enum.GetValues<FletchingType>())
        .Build()
        .StartMenuForSelectedItem();
    Console.WriteLine();

    var userArrowShaftLengthCm = InputUtility.AskUserForValueInRange(0.0f, float.MaxValue, "Enter the length of the shaft: ");

    return new(userArrowArrowheadType, userArrowFletchingType, userArrowShaftLengthCm);
}

internal enum UserArrowOption
{
    Elite,
    Beginner,
    Marksman,
    Custom,
}
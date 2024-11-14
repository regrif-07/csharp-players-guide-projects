using Utility;

var userArrowArrowheadType = new ConsoleMenuBuilder<ArrowheadType>()
    .SetTitle("Select the arrowhead type:")
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
Console.WriteLine();

var userArrow = new Arrow(userArrowArrowheadType, userArrowFletchingType, userArrowShaftLengthCm);
Console.WriteLine($"The cost of your arrow is {userArrow.GetCost():0.00} gold");
using Utility;

var triangleBase = InputUtility.AskUserForValue<double>("Enter triangle's base: ");
var triangleHeight = InputUtility.AskUserForValue<double>("Enter triangle's height: ");

var triangleArea = (triangleBase * triangleHeight) / 2.0;
Console.WriteLine($"Triangle's area is: {triangleArea}.");
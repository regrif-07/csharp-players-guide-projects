// this task was already solved by the Utility class library (InputUtility in particular)
using Utility;

var num = InputUtility.AskUserForValue<int>("Enter a number: ");
var numInRange = InputUtility.AskUserForValueInRange(1, 10, "Enter a number in the range from 1 to 10: ");
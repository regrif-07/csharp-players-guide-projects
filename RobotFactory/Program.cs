using System.Dynamic;
using Utility;

int robotCounter = 0;
while (true)
{
    dynamic robot = new ExpandoObject();
    robot.ID = ++robotCounter;

    Console.WriteLine($"You are producing robot #{robot.ID}.");

    if (InputUtility.AskUserYesNo("Do you want to name this robot? "))
    {
        robot.Name = InputUtility.AskUserForValue<string>("What is its name? ");
    }
    if (InputUtility.AskUserYesNo("Does this robot have a specific size? "))
    {
        robot.Height = InputUtility.AskUserForValueInRange(0.0, double.MaxValue, "What is its height? ");
        robot.Width = InputUtility.AskUserForValueInRange(0.0, double.MaxValue, "What is its width? ");
    }
    if (InputUtility.AskUserYesNo("Does this robot need to be a specific color? "))
    {
        robot.Color = InputUtility.AskUserForValue<string>("What color? ");
    }

    Console.WriteLine();
    DisplayExpandoObjectProperties(robot);
    Console.WriteLine();
}

void DisplayExpandoObjectProperties(dynamic expandoObject)
{
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)expandoObject)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }
}
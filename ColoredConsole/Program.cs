// since I already created such a utility class in the Utility project, I will use it instead of creating a new one

using Utility;

string name = Prompt("What is your name? ");
OutputUtility.WriteLineColored("Hello " + name, ConsoleColor.Green);

string Prompt(string question)
{
    OutputUtility.WriteColored(question, ConsoleColor.Cyan);
    return InputUtility.AskUserForValue<string>();
}
using Feud.IField;
using Feud.McDroid;

// here is the traditional program entry point
// all other objectives were completed in many previous projects, such as FountainOfObjects

internal class Program
{
    private static void Main(string[] args)
    {
        var sheep = new Sheep();
        var cow = new Cow();

        var iFieldPig = new Feud.IField.Pig();
        var mcDroidPig = new Feud.McDroid.Pig();
    }
}
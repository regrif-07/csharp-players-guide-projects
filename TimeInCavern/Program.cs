using FountainOfObjects;
using FountainOfObjects.CavernComponents;
using Utility;

const ConsoleColor VictoryColor = ConsoleColor.Green;
const ConsoleColor DefeatColor = ConsoleColor.Red;

DisplayIntro();

var worldSizeSelectionMenu = new ConsoleMenuBuilder<string>()
    .SetTitle("Select the world size:")
    .AddItems("Small", "Medium", "Large")
    .Build();

var cavern = worldSizeSelectionMenu.StartMenuForSelectedItem() switch
{
    "Small" => CavernPresetsBuilder.BuildSmallCavernPreset(),
    "Medium" => CavernPresetsBuilder.BuildMediumCavernPreset(),
    "Large" => CavernPresetsBuilder.BuildLargeCavernBuilder(),
    _ => throw new NotImplementedException()
};
Console.Clear();

var fountainOfObjectsGame = new Game(cavern);

var gameStartTime = DateTime.Now;
var isVictory = fountainOfObjectsGame.Start();
var gameEndTime = DateTime.Now;

Console.WriteLine();
if (isVictory)
{
    OutputUtility.WriteLineColored("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", VictoryColor);
}
else
{
    OutputUtility.WriteLineColored("You failed your mission and remained forever buried in this cavern...\nYou lost!", DefeatColor);
}

var gameTime = gameEndTime - gameStartTime;
Console.WriteLine($"\nYou spent {gameTime.Seconds} second(s) in the cavern.");

void DisplayIntro()
{
    Console.Clear();

    Console.WriteLine(
            """
            **********************************************************************************
            You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search
            of the Fountain of Objects.

            Light is visible only in the entrance, and no other light is seen anywhere in the caverns.
            You must navigate the Caverns with your other senses.

            Find the Fountain of Objects, activate it, and return to the entrance.

            Look out for pits. You will feel a breeze if a pit is in an adjacent room. 
            If you enter a room with a pit, you will die.

            Maelstroms are violent forces of sentient wind. 
            Entering a room with one could transport you to any other location in the caverns.
            You will be able to hear their growling and groaning in nearby rooms.

            Amaroks roam the caverns. 
            Encountering one is certain death, but you can smell their rotten stench in nearby rooms.

            You carry with you a bow and a quiver of arrows.
            You can use them to shoot monsters in the caverns but be warned: you have a limited supply.
            **********************************************************************************
            """);
    InputUtility.PressAnyKeyToContinue();

    Console.Clear();
}
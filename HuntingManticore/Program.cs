using Utility;

// manticore
const int ManticoreMaxHp = 10;
const int ManticoreMinDistance = 0;
const int ManticoreMaxDistance = 100;
const int ManticoreDamage = 1;

// city
const int CityMaxHp = 15;

// cannon
const int FireBlastMultiplier = 3;
const int ElectricBlastMultiplier = 5;

const int NormalBlastDamage = 1;
const int FireBlastDamage = 3;
const int ElectricBlastDamage = 3;
const int CombinedBlastDamage = 10;

const ConsoleColor NormalBlastColor = ConsoleColor.White;
const ConsoleColor FireBlastColor = ConsoleColor.Red;
const ConsoleColor ElectricBlastColor = ConsoleColor.Yellow;
const ConsoleColor CombinedBlastColor = ConsoleColor.Blue;

// misc
const ConsoleColor FellShortMsgColor = ConsoleColor.DarkYellow;
const ConsoleColor OvershotMsgColor = ConsoleColor.DarkRed;
const ConsoleColor DirectHitMsgColor = ConsoleColor.DarkGreen;

const ConsoleColor VictoryMsgColor = ConsoleColor.Green;
const ConsoleColor DefeatMsgColor = ConsoleColor.Red;

var manticoreDistance = InputUtility.AskUserForValueInRange(
    ManticoreMinDistance, 
    ManticoreMaxDistance, 
    "Player 1, how far away from the city do you want to station the Manticore? ");
Console.Clear();

Console.WriteLine("Player 2, it is your turn.");

int round = 0;
int manticoreHp = ManticoreMaxHp;
int cityHp = CityMaxHp;
while (true)
{
    ++round;

    DisplayDelimiter();
    DisplayStatus(round, cityHp, manticoreHp);

    var blastDamage = PrepareCannonBlast(round);
    var blastRange = InputUtility.AskUserForValueInRange(ManticoreMinDistance, ManticoreMaxDistance, "Enter desired cannon range: ");

    if (blastRange < manticoreDistance)
    {
        OutputUtility.WriteLineColored("That round FELL SHORT of the target.", FellShortMsgColor);
    }
    else if (blastRange > manticoreDistance)
    {
        OutputUtility.WriteLineColored("That round OVERSHOT the target.", OvershotMsgColor);
    }
    else
    {
        OutputUtility.WriteLineColored("That round was a DIRECT HIT!", DirectHitMsgColor);
        manticoreHp -= blastDamage;
    }

    // player victory
    if (manticoreHp <= 0)
    {
        OutputUtility.WriteLineColored("\nThe Manticore has been destroyed! The city of Consolas has been saved!", VictoryMsgColor);
        break;
    }

    cityHp -= ManticoreDamage;
    // player defeat
    if (cityHp <= 0)
    {
        OutputUtility.WriteLineColored("\nThe city of Consolas has been destroyed...", DefeatMsgColor);
        break;
    }
}

void DisplayDelimiter()
{
    Console.WriteLine("-----------------------------------------------------------");
}

void DisplayStatus(int round, int cityHp, int manticoreHp)
{
    Console.WriteLine($"STATUS: Round: {round} City: {cityHp}/{CityMaxHp} Manticore: {manticoreHp}/{ManticoreMaxHp}");
}

// calculates expected cannon damage and returns it
// also, displays an appropriate blast message
int PrepareCannonBlast(int round)
{
    var isFireBlast = round % FireBlastMultiplier == 0;
    var isElectricBlast = round % ElectricBlastMultiplier == 0;

    int blastDamage = NormalBlastDamage;
    ConsoleColor blastColor = NormalBlastColor;
    if (isFireBlast && isElectricBlast)
    {
        blastDamage = CombinedBlastDamage;
        blastColor = CombinedBlastColor;
    }
    else if (isFireBlast)
    {
        blastDamage = FireBlastDamage;
        blastColor = FireBlastColor;
    }
    else if (isElectricBlast)
    {
        blastDamage = ElectricBlastDamage;
        blastColor = ElectricBlastColor;
    }

    OutputUtility.WriteLineColored($"The cannon is expected to deal {blastDamage} damage this round.", blastColor);

    return blastDamage;
}
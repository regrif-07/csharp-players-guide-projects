using Utility;

IManticoreDistancePicker manticoreDistancePicker = InputUtility.AskUserYesNo("Do you want to play multiplayer mode? (yes/no) ") 
    ? new PlayerManticoreDistancePicker() 
    : new RandomManticoreDistancePicker();
Console.Clear();

var manticoreDistance = manticoreDistancePicker.PickManticoreDistnace();
Console.Clear();

Console.WriteLine("Now it's time to defend the city of Consolas!");

int round = 0;
int manticoreHp = ManticoreConstants.MaxHp;
int cityHp = CityConstants.MaxHp;
while (true)
{
    ++round;

    DisplayDelimiter();
    DisplayStatus(round, cityHp, manticoreHp);

    var blastDamage = PrepareCannonBlast(round);
    var blastRange = InputUtility.AskUserForValueInRange(ManticoreConstants.MinDistance, ManticoreConstants.MaxDistance, "Enter desired cannon range: ");

    if (blastRange < manticoreDistance)
    {
        OutputUtility.WriteLineColored("That round FELL SHORT of the target.", ColorConstants.FellShortMsgColor);
    }
    else if (blastRange > manticoreDistance)
    {
        OutputUtility.WriteLineColored("That round OVERSHOT the target.", ColorConstants.OvershotMsgColor);
    }
    else
    {
        OutputUtility.WriteLineColored("That round was a DIRECT HIT!", ColorConstants.DirectHitMsgColor);
        manticoreHp -= blastDamage;
    }

    // player victory
    if (manticoreHp <= 0)
    {
        OutputUtility.WriteLineColored("\nThe Manticore has been destroyed! The city of Consolas has been saved!", ColorConstants.VictoryMsgColor);
        break;
    }

    cityHp -= ManticoreConstants.Damage;
    // player defeat
    if (cityHp <= 0)
    {
        OutputUtility.WriteLineColored("\nThe city of Consolas has been destroyed...", ColorConstants.DefeatMsgColor);
        break;
    }
}

void DisplayDelimiter()
{
    Console.WriteLine("-----------------------------------------------------------");
}

void DisplayStatus(int round, int cityHp, int manticoreHp)
{
    Console.WriteLine($"STATUS: Round: {round} City: {cityHp}/{CityConstants.MaxHp} Manticore: {manticoreHp}/{ManticoreConstants.MaxHp}");
}

// calculates expected cannon damage and returns it
// also, displays an appropriate blast message
int PrepareCannonBlast(int round)
{
    var isFireBlast = round % CannonConstants.FireBlastMultiplier == 0;
    var isElectricBlast = round % CannonConstants.ElectricBlastMultiplier == 0;

    int blastDamage = CannonConstants.NormalBlastDamage;
    ConsoleColor blastColor = ColorConstants.NormalBlastColor;
    if (isFireBlast && isElectricBlast)
    {
        blastDamage = CannonConstants.CombinedBlastDamage;
        blastColor = ColorConstants.CombinedBlastColor;
    }
    else if (isFireBlast)
    {
        blastDamage = CannonConstants.FireBlastDamage;
        blastColor = ColorConstants.FireBlastColor;
    }
    else if (isElectricBlast)
    {
        blastDamage = CannonConstants.ElectricBlastDamage;
        blastColor = ColorConstants.ElectricBlastColor;
    }

    OutputUtility.WriteLineColored($"The cannon is expected to deal {blastDamage} damage this round.", blastColor);

    return blastDamage;
}

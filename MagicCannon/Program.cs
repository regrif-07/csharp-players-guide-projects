using Utility;

const int FinalBlastNum = 100;

const int FireBlastMultiplier = 3;
const int ElectricBlastMultiplier = 5;

const ConsoleColor FireBlastColor = ConsoleColor.Red;
const ConsoleColor ElectricBlastColor = ConsoleColor.Yellow;
const ConsoleColor CombinedBlastColor = ConsoleColor.Blue;

if (FinalBlastNum < 1)
{
    throw new NotSupportedException("final blast number should be greater than one");
}

for (int blastNum = 1; blastNum <= FinalBlastNum; ++blastNum)
{
    bool isFireBlast = blastNum % FireBlastMultiplier == 0;
    bool isElectricBlast = blastNum % ElectricBlastMultiplier == 0;

    string blastName = "Normal";
    ConsoleColor? blastColor = null;
    if (isFireBlast && isElectricBlast)
    {
        blastName = "Combined";
        blastColor = CombinedBlastColor;
    }
    else if (isFireBlast)
    {
        blastName = "Fire";
        blastColor = FireBlastColor;
    }
    else if (isElectricBlast)
    {
        blastName = "Electric";
        blastColor = ElectricBlastColor;
    }

    OutputUtility.WriteLineColored($"{blastNum}: {blastName}", blastColor);
}
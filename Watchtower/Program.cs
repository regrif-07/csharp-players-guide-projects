using System.Text;
using Utility;

Console.WriteLine("Enter the position of the enemy:");
var enemyPosX = InputUtility.AskUserForValue<int>("X: ");
var enemyPosY = InputUtility.AskUserForValue<int>("Y: ");

if (enemyPosX == 0 && enemyPosY == 0)
{
    Console.WriteLine("The enemy is here!");
    return;
}

var enemyDirectionNameSb = new StringBuilder();
if (enemyPosY > 0)
{
    enemyDirectionNameSb.Append("north");
}
else if (enemyPosY < 0)
{
    enemyDirectionNameSb.Append("south");
}
if (enemyPosX > 0)
{
    enemyDirectionNameSb.Append("east");
}
else if (enemyPosX < 0)
{
    enemyDirectionNameSb.Append("west");
}

Console.WriteLine($"The enemy is to the {enemyDirectionNameSb}!");
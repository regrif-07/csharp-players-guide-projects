using FinalBattle.Characters;
using FinalBattle.Parties;
using System.Text;

namespace FinalBattle;

internal static class PartiesStatusDisplayer
{
    private const int DisplayWidth = 97;

    public static void Display(Game game)
    {
        DisplayHeader();
        DisplayHeroes(game.HeroesParty);
        DisplayVersus();
        DisplayMonsters(game.MonstersParty);
        DisplayFooter();
    }

    private static void DisplayHeroes(Party heroesParty)
    {
        foreach (var hero in heroesParty.Characters)
        {
            Console.WriteLine(GetCharacterStatus(hero));
        }
    }

    private static void DisplayMonsters(Party monstersParty)
    {
        foreach (var monster in monstersParty.Characters)
        {
            Console.WriteLine(string.Format($"{{0,{DisplayWidth}}}", GetCharacterStatus(monster)));
        }
    }

    private static void DisplayHeader() => Console.WriteLine("============================================= BATTLE ============================================");
    private static void DisplayVersus() => Console.WriteLine("---------------------------------------------- VS -----------------------------------------------");
    private static void DisplayFooter() => Console.WriteLine("=================================================================================================");

    private static string GetCharacterStatus(Character character)
    {
        var characterStatusSb = new StringBuilder($"{character.Name} ( {character.CurrentHp}/{character.MaxHp} )");
        if (character.Gear != null)
        {
            characterStatusSb.Append($" [{character.Gear.Name}]");
        }
        
        return characterStatusSb.ToString();
    }
}

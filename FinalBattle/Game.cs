using FinalBattle.InventorySystem.Items;
using FinalBattle.Parties;

namespace FinalBattle;

internal enum GameStatus
{
    InProcess,
    HeroesVictory,
    MonstersVitory,
}

internal class Game
{
    private readonly Queue<Party> _monstersPartiesQueue;

    public Game(Party heroesParty, params Party[] monsterParties)
    {
        if (monsterParties.Length == 0)
        {
            throw new ArgumentException("game should start with at least one monster party");
        }
        if (monsterParties.Any(mp => mp.IsDefeated))
        {
            throw new ArgumentException("one of the provided monster parties was empty");
        }

        HeroesParty = heroesParty;
        _monstersPartiesQueue = new(monsterParties);
        MonstersParty = _monstersPartiesQueue.Dequeue();

        CurrentParty = HeroesParty;
    }

    public Party HeroesParty { get; }
    public Party MonstersParty { get; private set; }
    public Party CurrentParty { get; private set; }
    public Party OppositeParty { get => (CurrentParty == HeroesParty) ? MonstersParty : HeroesParty; }

    public GameStatus Start()
    {
        while (true)
        {
            PartiesStatusDisplayer.Display(this);

            Console.WriteLine($"{CurrentParty.Name} are making their moves...\n");

            foreach (var character in CurrentParty.Characters)
            {
                Console.WriteLine($"It is {character.Name}'s turn...");

                var pickedAction = CurrentParty.ActionPicker.Pick(character, this);
                pickedAction.Perform();

                var stolenGear = OppositeParty.DeleteDeadCharacters();
                if (stolenGear.Count() > 0)
                {
                    CurrentParty.Inventory.AddItems(stolenGear.ToArray());

                    foreach (var gear in stolenGear)
                    {
                        Console.WriteLine($"{CurrentParty.Name} acquired {gear.Name}.");
                    }
                }
                if (OppositeParty.IsDefeated)
                {
                    if (OppositeParty == HeroesParty)
                    {
                        return GameStatus.MonstersVitory;
                    }
                    else if (!AdvanceMonsterParty())
                    {
                        return GameStatus.HeroesVictory;
                    }
                }

                Console.WriteLine();
            }

            SwitchCurrentParty();
        }
    }

    // returns true if the current monster party was changed, false otherwise
    private bool AdvanceMonsterParty()
    {
        Console.WriteLine("\nThis pack of monsters was defeated.");
        if (_monstersPartiesQueue.Count == 0)
        {
            Console.WriteLine("And it was the final one!\n");
            return false;
        }

        var oldMonsterPartyItems = new List<IInventoryItem>();
        while (!MonstersParty.Inventory.IsEmpty)
        {
            oldMonsterPartyItems.Add(MonstersParty.Inventory.GrabItemByType<IInventoryItem>()!);
        }

        if (oldMonsterPartyItems.Count() > 0)
        {
            HeroesParty.Inventory.AddItems(oldMonsterPartyItems.ToArray());

            Console.WriteLine($"{HeroesParty.Name} acquired the following items:");
            foreach (var item in oldMonsterPartyItems)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        Console.WriteLine("Yet another one approaches...\n");
        MonstersParty = _monstersPartiesQueue.Dequeue();
        Console.WriteLine($"{MonstersParty.Name} are now on the battlefield.");
        return true;
    }

    private void SwitchCurrentParty() => CurrentParty = OppositeParty;
}
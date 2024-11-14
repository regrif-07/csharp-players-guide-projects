using System.Collections.ObjectModel;
using FinalBattle.ActionPickers;
using FinalBattle.Characters;
using FinalBattle.InventorySystem;
using FinalBattle.InventorySystem.Items;

namespace FinalBattle.Parties;

internal class Party
{
    private readonly List<Character> _characters;

    public Party(string name, IActionPicker actionPicker, IEnumerable<Character> characters, IEnumerable<IInventoryItem> inventoryItems)
    {
        Name = name;
        ActionPicker = actionPicker;
        _characters = characters.ToList();
        Inventory = new Inventory(inventoryItems.ToArray());
        Characters = _characters.AsReadOnly();
    }

    public string Name { get; }
    public IActionPicker ActionPicker { get; }
    public ReadOnlyCollection<Character> Characters { get; }
    public Inventory Inventory { get; }
    public bool IsDefeated => !_characters.Any();

    // returns the list of dead characters gear
    public List<Gear> DeleteDeadCharacters(bool announce = true)
    {
        var deadCharacters = _characters.Where(c => c.IsDead).ToList();

        if (announce && deadCharacters.Any())
        {
            Console.WriteLine(); // display a newline to separate the new dead characters status output
        }

        var deadCharactersGear = new List<Gear>();
        foreach (var deadCharacter in deadCharacters)
        {
            _characters.Remove(deadCharacter);
            if (deadCharacter.Gear != null)
            {
                deadCharactersGear.Add(deadCharacter.Gear);
            }

            if (announce)
            {
                Console.WriteLine($"{deadCharacter.Name} has been defeated!");
            }
        }

        return deadCharactersGear;
    }
}

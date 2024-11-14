using FinalBattle.ActionPickers;
using FinalBattle.Characters;
using FinalBattle.InventorySystem.Items;

namespace FinalBattle.Parties;

internal class PartyBuilder
{
    private string _name = "UNNAMED PARTY";
    private IActionPicker _actionPicker = new BotActionPicker();
    private List<Character> _characters = new();
    private List<IInventoryItem> _inventoryItems = new();

    public PartyBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public PartyBuilder SetActionPicker(IActionPicker actionPicker)
    {
        _actionPicker = actionPicker;
        return this;
    }

    public PartyBuilder AddCharacters(params Character[] characters)
    {
        _characters.AddRange(characters);
        return this;
    }

    public PartyBuilder AddInventoryItems(params IInventoryItem[] inventoryItems)
    {
        _inventoryItems.AddRange(inventoryItems);
        return this;
    }

    public Party Build() => new Party(_name, _actionPicker, _characters, _inventoryItems);
}

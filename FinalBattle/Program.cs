using FinalBattle;
using FinalBattle.ActionPickers;
using FinalBattle.Characters;
using FinalBattle.InventorySystem.Items;
using FinalBattle.Parties;
using Utility;

var gameModeSelectionMenu = new ConsoleMenuBuilder<(IActionPicker, IActionPicker)>()
    .SetTitle("Select the game mode:")
    .SetFixedItemNames("Player vs. Bot", "Bot vs. Bot", "Player vs. Player")
    .AddItems((new PlayerActionPicker(), new BotActionPicker()), (new BotActionPicker(), new BotActionPicker()), (new PlayerActionPicker(), new PlayerActionPicker()))
    .Build();
var (heroesActionPicker, monstersActionPicker) = gameModeSelectionMenu.StartMenuForSelectedItem();

Console.Clear(); // clear the screen after the game mode selection menu
var game = new Game(BuildHeroesParty(heroesActionPicker), BuildMonsterParties(monstersActionPicker));
Console.Clear(); // clear the screen because some character builders may need user input

switch (game.Start())
{
    case GameStatus.HeroesVictory:
        Console.WriteLine("The heroes won, and the Uncoded One was defeated!");
        break;

    case GameStatus.MonstersVitory:
        Console.WriteLine("\nThe heroes lost and the Uncoded One’s forces have prevailed...");
        break;

    default:
        throw new InvalidOperationException("invalid final game status");
}

Party BuildHeroesParty(IActionPicker actionPicker) => new PartyBuilder()
    .SetName("HEROES")
    .SetActionPicker(actionPicker)
    .AddCharacters(
        CharacterBuilder.BuildTrueProgrammer(InputUtility.AskUserForValue<string>("Enter your name, hero: "), GearPresets.Sword),
        CharacterBuilder.BuildVinFletcher(GearPresets.VinsBow)
    )
    .AddInventoryItems(new HealthPotionItem(), new HealthPotionItem(), new HealthPotionItem())
    .Build();

Party[] BuildMonsterParties(IActionPicker actionPicker)
{
    return [
        new PartyBuilder()
            .SetName("MONSTERS #1")
            .SetActionPicker(actionPicker)
            .AddCharacters(CharacterBuilder.BuildSkeleton(GearPresets.Dagger))
            .AddInventoryItems(new HealthPotionItem())
            .Build(),
        new PartyBuilder()
            .SetName("MONSTERS #2")
            .SetActionPicker(actionPicker)
            .AddCharacters(CharacterBuilder.BuildSkeleton(), CharacterBuilder.BuildSkeleton())
            .AddInventoryItems(new HealthPotionItem(), GearPresets.Dagger, GearPresets.Dagger)
            .Build(),
        new PartyBuilder()
            .SetName("MONSTERS #3")
            .SetActionPicker(actionPicker)
            .AddCharacters(CharacterBuilder.BuildStoneAmarok(), CharacterBuilder.BuildStoneAmarok())
            .AddInventoryItems(new HealthPotionItem())
            .Build(),
        new PartyBuilder()
            .SetName("MONSTERS FINAL")
            .SetActionPicker(actionPicker)
            .AddCharacters(CharacterBuilder.BuildUncodedOne())
            .AddInventoryItems(new HealthPotionItem())
            .Build(),
    ];
}
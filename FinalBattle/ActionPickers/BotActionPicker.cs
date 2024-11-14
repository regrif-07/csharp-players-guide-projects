using FinalBattle.Actions;
using FinalBattle.Characters;
using FinalBattle.InventorySystem.Items;
using Utility;

namespace FinalBattle.ActionPickers;

internal class BotActionPicker : IActionPicker
{
#if DEBUG
    private const int DelayMs = 0;
#else
    private const int DelayMs = 1000;
#endif
    private const double LowHpThresholdFraction = 0.5;
    private const double HealthPotionUsageChanceFraction = 0.25;

    public IAction Pick(Character performer, Game game)
    {
        Thread.Sleep(DelayMs);

        if ((performer.CurrentHp <= performer.MaxHp * LowHpThresholdFraction) &&
            (Random.Shared.CoinFlip(HealthPotionUsageChanceFraction)) &&
            (game.CurrentParty.Inventory.HasItemByType<HealthPotionItem>()))
        {
            return new UseItemAction(game, performer, game.CurrentParty.Inventory.GrabItemByType<HealthPotionItem>()!, performer);
        }

        if (performer.Gear == null && Random.Shared.CoinFlip() && game.CurrentParty.Inventory.HasItemByType<Gear>())
        {
            return new UseItemAction(game, performer, game.CurrentParty.Inventory.GrabItemByType<Gear>()!, performer);
        }

        var randomAttackTarget = game.OppositeParty.Characters[Random.Shared.Next(game.OppositeParty.Characters.Count())];
        var attack = (performer.Gear == null) ? performer.StandardAttack : performer.Gear.Attack;
        return new AttackAction(performer, attack, randomAttackTarget);
    }
}

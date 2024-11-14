using FinalBattle.Characters;

namespace FinalBattle.Actions;

internal class DoNothingAction : IAction
{
    private readonly Character _performer;

    public DoNothingAction(Character performer)
    {
        _performer = performer;
    }

    public void Perform()
    {
        Console.WriteLine($"{_performer.Name} did NOTHING.");
    }
}

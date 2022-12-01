namespace KOT.Controllers;

using KOT.Controllers.PlayerActions;
using KOT.Models;

public class DiceAnalyzer
{
    private readonly GainEnergyCube GainEnergy = new GainEnergyCube();
    private readonly GainLifePoints GainLife = new GainLifePoints();
    private readonly GainVictoryPoints GainVictory = new GainVictoryPoints();
    private readonly SmashMonsters Smash = new SmashMonsters();

    public void ResolveDice(List<string> dices, PlayerPayload player)
    {
        var groupDices = dices.GroupBy(dice => dice);
        foreach (var group in groupDices)
        {
            if ((group.Key == "one" || group.Key == "two" || group.Key == "three") && group.Count() >= 3)
            {
                GainVictory.Execute(dices, player);
            }

            if (group.Key == "heart")
            {
                GainLife.Execute(dices, player);
            }

            if (group.Key == "energy")
            {
                GainEnergy.Execute(dices, player);
            }
            else
            {
                Smash.Execute(dices, player);
            }
        }
    }
}

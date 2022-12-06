namespace KOT.Controllers.PowerCardsActions;
using KOT.Models;
using KOT.Services.Processors;
using KOT.Models.Processor;
using KOT.Controllers.Abstracts;

public class ExecutePowerCard 
{
    public void ExecuteEffect(Effect effect, Player player) { }

    public void Execute(string[] dices, GamePayload game)
    {
        if (
            game.Players!.Find(player => player.Name == game.ActivePlayerName)!.PowerCards!.Count()
            > 0
        )
        {
            foreach (var powerCard in game.Players!.Find(player => player.Name == game.ActivePlayerName)!.PowerCards!)
            {
                
                // player.EnergyCubes += effect.EnergyPoints;
                // player.MyMonster.VictoryPoints += effect.StarPoints;
                // player.MyMonster.LifePoints += effect.HeartPoints;
                // if (effect.DamagePoints > 0) { }
                // if (effect.CostReduction > 0) { }
            }
        }
    }
}

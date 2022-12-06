namespace KOT.Controllers.PowerCardsActions;
using KOT.Models;
using KOT.Controllers.Abstracts;

public class ExecutePowerCard : PowerCardAction<ExecutePowerCard>
{
    public override void Execute(GamePayload game)
    {
        if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.PowerCards!.Count() > 0)
        {
            var player = game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!;
            var powerCards = player.PowerCards!;
            foreach (var powerCard in powerCards)
            {
                player.EnergyCubes += powerCard.effect.EnergyPoints;
                player.MyMonster.VictoryPoints += powerCard.effect.StarPoints;
                player.MyMonster.LifePoints += powerCard.effect.HeartPoints;
                if (powerCard.effect.DamagePoints > 0)
                {
                    for (int index = 0; index < game.Board?.OutsideTokyo!.Count(); index++)
                    {
                        if (game.Board?.OutsideTokyo![index].Name != player.Name)
                        {
                            game.Board!.OutsideTokyo![index].MyMonster.LifePoints -= powerCard.effect.DamagePoints;
                        }
                    }
                }
            }
        }
    }
}

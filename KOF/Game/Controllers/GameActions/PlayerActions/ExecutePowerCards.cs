namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class ExecutePowerCard : GameAction<ExecutePowerCard>
{
    public override void Execute(string[] dices, GamePayload game)
    {

        if (game.Board?.OutsideTokyo!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            ExecuteEffect(game.Board.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName)!);
        }

        if (game.Board?.TokyoCity!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            ExecuteEffect(game.Board.TokyoCity.Find(player => player.Name == game.ActivePlayerName)!);
        }

        if (game.Board!.TokyoBay != null && game.Board?.TokyoBay!.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            ExecuteEffect(game.Board.TokyoBay.Find(player => player.Name == game.ActivePlayerName)!);
        }
    }

    public void ExecuteEffect(Player player)
    {
        if (player.PowerCards!.Count() > 0)
        {
            foreach (var powerCard in player.PowerCards!)
            {
                player.EnergyCubes += powerCard.effect.EnergyPoints;
                player.MyMonster.VictoryPoints += powerCard.effect.VictoryPoints;
                player.MyMonster.LifePoints += powerCard.effect.LifePoints;
            }
        }
    }
}

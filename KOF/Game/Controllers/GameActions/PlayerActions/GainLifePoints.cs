namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainLifePoints : GameAction<GainLifePoints>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        int hearts = dices.Where(dice => dice == "heart").Count();
        if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName) != null)
        {
            game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.LifePoints += hearts;
            if (game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.LifePoints > 10)
            {
                game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.LifePoints = 10;
            }
        }
    }
}

namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainLifePoints : PlayerAction<GainLifePoints>
{
    public override void Execute(List<string> dices, PlayerPayload player)
    {
        int hearts = dices.Where(dice => dice == "heart").Count();
        player.MyMonster!.LifePoints += hearts;
        if (player.MyMonster!.LifePoints > 10)
        {
            player.MyMonster!.LifePoints = 10;
        }
    }
}

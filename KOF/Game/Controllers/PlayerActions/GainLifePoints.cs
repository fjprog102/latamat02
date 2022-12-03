﻿namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainLifePoints : PlayerAction<GainLifePoints>
{
    public override void Execute(List<string> dices, GamePayload game)
    {
        int hearts = dices.Where(dice => dice == "heart").Count();
        if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName) != null)
        {
            game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName)!.MyMonster.LifePoints += hearts;
            if (game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName)!.MyMonster.LifePoints > 10)
            {
                game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName)!.MyMonster.LifePoints = 10;
            }
        }
    }
}

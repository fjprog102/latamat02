namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class SmashMonsters : GameAction<SmashMonsters>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        int smash = dices.Where(dice => dice == "smash").Count();

        if (game.Board?.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            if (game.Board!.TokyoBay != null)
            {
                for (int index = 0; index < game.Board?.TokyoBay!.Count(); index++)
                {
                    game.Board!.TokyoBay![index].MyMonster.LifePoints -= smash;
                }
            }

            for (int index = 0; index < game.Board?.TokyoCity!.Count(); index++)
            {
                game.Board!.TokyoCity[index].MyMonster.LifePoints -= smash;
            }
        }
        else
        {
            for (int index = 0; index < game.Board?.OutsideTokyo!.Count(); index++)
            {
                game.Board!.OutsideTokyo![index].MyMonster.LifePoints -= smash;
            }
        }
    }
}

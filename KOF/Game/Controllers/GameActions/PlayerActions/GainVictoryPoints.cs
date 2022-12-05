namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainVictoryPoints : GameAction<GainVictoryPoints>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        int points = CountVictoryPoints(dices);

        if (game.Board!.TokyoBay != null)
        {
            if (game.Board?.TokyoBay!.Find(player => player.Name == game.ActivePlayerName) != null)
            {
                game.Board!.TokyoBay!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += points;
            }
        }

        if (game.Board?.TokyoCity!.Find(player => player.Name == game.ActivePlayerName) != null)
        {
            game.Board!.TokyoCity!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += points;
        }

        if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName) != null)
        {
            game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += points;
        }
    }

    public int CountVictoryPoints(string[] dices)
    {
        int points = 0;
        var groupDices = dices.GroupBy(dice => dice);
        foreach (var group in groupDices)
        {
            if (group.Count() >= 3)
            {
                points = group.Count() - 3;
                if (group.Key == "one")
                {
                    points += 1;
                }

                if (group.Key == "two")
                {
                    points += 2;
                }

                if (group.Key == "three")
                {
                    points += 3;
                }
            }
        }

        return points;
    }
}

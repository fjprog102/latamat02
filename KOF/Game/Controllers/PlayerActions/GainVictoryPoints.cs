namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainVictoryPoints : PlayerAction<GainVictoryPoints>
{
    public override void Execute(List<string> dices, PlayerPayload player)
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

        player.MyMonster!.VictoryPoints += points;
    }
}

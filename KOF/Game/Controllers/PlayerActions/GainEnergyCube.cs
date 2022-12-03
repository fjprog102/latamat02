namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainEnergyCube : PlayerAction<GainEnergyCube>
{
    public override void Execute(List<string> dices, GamePayload game)
    {
        {
            int energyCubes = dices.Where(dice => dice == "energy").Count();

            if (game.Board!.TokyoBay != null)
            {
                if (game.Board?.TokyoBay!.Find(player => player.Name == game.ActiveUserName) != null)
                {
                    game.Board!.TokyoBay!.Find(player => player.Name == game.ActiveUserName)!.EnergyCubes += energyCubes;
                }
            }

            if (game.Board?.TokyoCity!.Find(player => player.Name == game.ActiveUserName) != null)
            {
                game.Board!.TokyoCity!.Find(player => player.Name == game.ActiveUserName)!.EnergyCubes += energyCubes;
            }

            if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName) != null)
            {
                game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActiveUserName)!.EnergyCubes += energyCubes;
            }
        }
    }
}

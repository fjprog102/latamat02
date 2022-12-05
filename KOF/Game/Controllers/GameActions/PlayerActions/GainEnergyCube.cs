namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainEnergyCube : GameAction<GainEnergyCube>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        {
            int energyCubes = dices.Where(dice => dice == "energy").Count();

            if (game.Board!.TokyoBay != null)
            {
                if (game.Board?.TokyoBay!.Find(player => player.Name == game.ActivePlayerName) != null)
                {
                    game.Board!.TokyoBay!.Find(player => player.Name == game.ActivePlayerName)!.EnergyCubes += energyCubes;
                }
            }

            if (game.Board?.TokyoCity!.Find(player => player.Name == game.ActivePlayerName) != null)
            {
                game.Board!.TokyoCity!.Find(player => player.Name == game.ActivePlayerName)!.EnergyCubes += energyCubes;
            }

            if (game.Board?.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName) != null)
            {
                game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName)!.EnergyCubes += energyCubes;
            }
        }
    }
}

namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class GainEnergyCube : PlayerAction<GainEnergyCube>
{
    public override void Execute(List<string> dices, PlayerPayload player)
    {
        {
            int energyCubes = dices.Where(dice => dice == "energy").Count();
            player.EnergyCubes += energyCubes;
        }
    }
}

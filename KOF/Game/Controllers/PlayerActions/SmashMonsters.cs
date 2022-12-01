namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class SmashMonsters : PlayerAction<SmashMonsters>
{
    public override void Execute(List<string> dices, PlayerPayload player)
    {
        int smashFace = dices.Where(dice => dice == "smash").Count();
    }
}

namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class StartTurn : GameAction<StartTurn>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        if (game.Board!.TokyoCity.Exists(player => player.Name == game.ActivePlayerName) == true)
        {
            game.Board.TokyoCity.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += 2;
        }
        else if (game.Board!.TokyoBay != null)
        {
            if (game.Board!.TokyoBay.Exists(player => player.Name == game.ActivePlayerName) == true)
            {
                game.Board.TokyoBay.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += 2;
            }
        }
    }
}

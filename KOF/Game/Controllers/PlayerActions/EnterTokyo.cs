namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class EnterTokyo : PlayerAction<EnterTokyo>
{
    public override void Execute(List<string> dices, GamePayload game)
    {
        if (game.Board!.TokyoCity.Count() == 0)
        {
            game.BoardProcessor!.ChangePlayerBoardPlace
            (game.Board!.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName)!, game.Board.OutsideTokyo, game.Board.TokyoCity);
            game.Board.TokyoCity.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += 1;
        }
        else if (game.Board!.TokyoBay != null)
        {
            if (game.Board!.TokyoBay.Count() == 0)
            {
                game.BoardProcessor!.ChangePlayerBoardPlace
                (game.Board!.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName)!, game.Board.OutsideTokyo, game.Board.TokyoBay);
                game.Board.TokyoBay.Find(player => player.Name == game.ActivePlayerName)!.MyMonster.VictoryPoints += 1;
            }
        }
    }
}

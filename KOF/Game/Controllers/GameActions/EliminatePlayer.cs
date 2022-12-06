namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class EliminatePlayer : GameAction<EliminatePlayer>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        RemovePlayer(game.Board!.OutsideTokyo);
        RemovePlayer(game.Board.TokyoCity);
        if (game.Board!.TokyoBay != null)
        {
            RemovePlayer(game.Board.TokyoBay);
        }

        if (game.Board!.OutsideTokyo.Count() + game.Board.TokyoBay!.Count() + game.Board.TokyoCity.Count() < 5)
        {
            MovePlayersFromTokyoBayToTokyoCity(game);
            game.Board.TokyoBay = null;
        }
    }

    public void RemovePlayer(List<Player> players)
    {
        for (int index = 0; index < players.Count(); index++)
        {
            if (players[index].MyMonster.LifePoints <= 0)
            {
                players.Remove(players[index]);
            }
        }
    }

    public void MovePlayersFromTokyoBayToTokyoCity(GamePayload game)
    {
        if (game.Board!.TokyoBay!.Count() > 0)
        {
            for (int index = 0; index < game.Board!.TokyoBay!.Count(); index++)
            {
                game.BoardProcessor!.ChangePlayerBoardPlace(game.Board!.TokyoBay![index], game.Board.TokyoBay, game.Board.TokyoCity);
            }
        }
    }
}

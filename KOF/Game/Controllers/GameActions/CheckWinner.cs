namespace KOT.Controllers.PlayerActions;

using KOT.Controllers.Abstracts;
using KOT.Models;

public class CheckWinner : GameAction<CheckWinner>
{
    public override void Execute(string[] dices, GamePayload game)
    {
        game.Winner = CheckWinnerInBoardPlace(game.Board!.OutsideTokyo) + CheckWinnerInBoardPlace(game.Board!.TokyoCity);
        if (game.Board!.TokyoBay != null)
        {
            game.Winner += CheckWinnerInBoardPlace(game.Board.TokyoBay);
        }
    }

    public string CheckWinnerInBoardPlace(List<Player> players)
    {
        string winner = "";
        for (int index = 0; index < players.Count(); index++)
        {
            if (players[index].MyMonster.VictoryPoints >= 20)
            {
                winner = players[index].Name;
            }
        }

        return winner;
    }
}

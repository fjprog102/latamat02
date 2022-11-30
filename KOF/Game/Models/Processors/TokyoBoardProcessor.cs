namespace KOT.Models.Processors;

using KOT.Models.Abstracts;

public class TokyoBoardProcessor
{
    public void ChangePlayerBoardPlace(Player player, List<Player>? originalPlace, List<Player>? newPlace)
    {
        originalPlace?.Remove(player);
        newPlace?.Add(player);
    }

    public void CheckAmountOfPlayers(List<Player> players)
    {
        if (players.Count() < 2)
        {
            throw new Exception("The game can't be played with less than 2 (two) players.");
        }

        if (players.Count() > 6)
        {
            throw new Exception("The game can't be played with more than 6 (six) players.");
        }
    }

    public void SetTokyoBoard(List<Player> players, TokyoBoard board)
    {
        if (players.Count() > 4 && players.Count() < 7)
        {
            board.TokyoBay = new List<Player>();
        }

        foreach (Player player in players)
        {
            board.OutsideTokyo.Add(player);
        }
    }
}

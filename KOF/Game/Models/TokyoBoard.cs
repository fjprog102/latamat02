namespace KOT.Models;

public class TokyoBoard
{
    public List<Player> TokyoCity = new List<Player>();
    public List<Player>? TokyoBay;
    public List<Player> OutsideTokyo = new List<Player>();

    public TokyoBoard(List<Player> players)
    {
        CheckAmountOfPlayers(players);
        foreach (Player player in players)
        {
            OutsideTokyo.Add(player);
        }
    }

    public void ChangePlayerBoardPlace(Player player, List<Player> originalPlace, List<Player> newPlace)
    {
        originalPlace.Remove(player);
        newPlace.Add(player);
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

        if (players.Count() > 4)
        {
            TokyoBay = new List<Player>();
        }
    }
}

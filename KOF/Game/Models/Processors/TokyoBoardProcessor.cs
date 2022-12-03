namespace KOT.Models.Processor;

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

    public Dictionary<int, string> FindPlayer(TokyoBoard board, string playerName)
    {
        Dictionary<int, string> playerPlace = new Dictionary<int, string>();

        for (int index = 0; index < board.OutsideTokyo.Count(); index++)
        {
            if (board.OutsideTokyo[0].Name == playerName)
            {
                playerPlace[index] = "OutsideTokyo";
            }
        }

        if (board.TokyoBay != null)
        {
            for (int index = 0; index < board.TokyoBay?.Count(); index++)
            {
                if (board.TokyoBay[0].Name == playerName)
                {
                    playerPlace[index] = "TokyoBay";
                }
            }
        }

        for (int index = 0; index < board.TokyoCity.Count(); index++)
        {
            if (board.TokyoCity[0].Name == playerName)
            {
                playerPlace[index] = "TokyoCity";
            }
        }

        return playerPlace;
    }
}

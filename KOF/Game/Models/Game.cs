namespace KOTGame.Models;

public class Game
{
    public int Id { get; set; }
    public string? TokyoBoard { get; set; }
    public int NumberOfPlayers { get; set; }
    public int ActiveUser { get; set; }
}

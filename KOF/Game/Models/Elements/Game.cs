namespace KOT.Models;

using KOT.Models.Abstracts;

public class Game : Element
{
    public string Id { get; set; }
    public TokyoBoard? Board { get; set; }

    public Game(TokyoBoard board)
    {
        Id = "12345678"; //Pending for bson ObjectId
        Board = board ?? throw new Exception("The board must be ready to initiliaze the Game.");
    }
}

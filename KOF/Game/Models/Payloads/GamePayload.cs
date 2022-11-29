using KOT.Models.Abstracts;

namespace KOT.Models;

public class GamePayload : DataHolder
{
    public TokyoBoard? Board { get; set; }

    public GamePayload(
        string? id = null,
        TokyoBoard? board = null
    )
    {
        Id = id;
        Board = board;
    }
}

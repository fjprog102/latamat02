using KOT.Models.Abstracts;
using KOT.Models.Processor;

namespace KOT.Models;

public class GamePayload : DataHolder
{
    public TokyoBoard? Board { get; set; }
    public TokyoBoardProcessor? BoardProcessor { get; set; }
    public string? ActiveUserName { get; set; }

    public GamePayload(
        string? id = null,
        TokyoBoard? board = null,
        TokyoBoardProcessor? boardProcessor = null,
        string? activeUserName = null
    )
    {
        Id = id;
        Board = board;
        ActiveUserName = activeUserName;
        BoardProcessor = boardProcessor;
    }
}

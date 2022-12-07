using KOT.Models.Abstracts;
using KOT.Models.Processor;

namespace KOT.Models;

public class GamePayload : DataHolder
{
    public TokyoBoard? Board { get; set; }
    public TokyoBoardProcessor? BoardProcessor { get; set; }
    public PowerCardDeck? Deck { get; set; }
    public string? ActivePlayerName { get; set; }
    public List<Player>? Players { get; set; }
    public string? Winner { get; set; }

    public GamePayload(
        string? id = null,
        TokyoBoard? board = null,
        TokyoBoardProcessor? boardProcessor = null,
        PowerCardDeck? deck = null,
        string? activePlayerName = null,
        List<Player>? players = null,
        string? winner = null
    )
    {
        Id = id;
        Board = board;
        ActivePlayerName = activePlayerName;
        BoardProcessor = boardProcessor;
        Deck = deck;
        Players = players;
        Winner = winner;
    }
}

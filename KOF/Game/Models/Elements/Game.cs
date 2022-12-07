namespace KOT.Models;

using KOT.Models.Abstracts;
using KOT.Models.Processor;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Game : Element
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Board")]
    public TokyoBoard? Board { get; set; }

    [BsonElement("BoardProcessor")]
    public TokyoBoardProcessor? BoardProcessor { get; set; }

    [BsonElement("ActivePlayerName")]
    public string? ActivePlayerName { get; set; }

    [BsonElement("Players")]
    public List<Player>? Players { get; set; }

    [BsonElement("PowerCardDeck")]
    public PowerCardDeck Deck { get; set; }

    [BsonElement("Winner")]
    public string? Winner { get; set; }

    public Game(List<Player> players)
    {
        Board = new TokyoBoard();
        BoardProcessor = new TokyoBoardProcessor();
        Deck = new PowerCardDeck();
        ActivePlayerName = players.First().Name;
        Players = players;
        Winner = "";
        BoardProcessor.SetTokyoBoard(Players, Board);
    }
}

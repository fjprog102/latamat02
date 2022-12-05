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

    [BsonElement("Winner")]
    public string? Winner { get; set; }

    public Game(TokyoBoard board, TokyoBoardProcessor boardProcessor, List<Player> players, string winner)
    {
        Board = board;
        BoardProcessor = boardProcessor;
        ActivePlayerName = null;
        Players = players;
        Winner = winner;
    }
}

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

    [BsonElement("ActiveUserName")]
    public string? ActivePlayerName { get; set; }

    public Game(TokyoBoard board, TokyoBoardProcessor boardProcessor)
    {
        Board = board ?? throw new Exception("The board must be ready to initiliaze the Game.");
        BoardProcessor = boardProcessor;
        ActivePlayerName = null;
    }
}

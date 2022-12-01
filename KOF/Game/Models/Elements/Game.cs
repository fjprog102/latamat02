namespace KOT.Models;

using KOT.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Game : Element
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Board")]
    public TokyoBoard? Board { get; set; }

    public Game(TokyoBoard board)
    {
        Id = "12345678"; //Pending for bson ObjectId
        Board = board ?? throw new Exception("The board must be ready to initiliaze the Game.");
    }
}

namespace KOT.Models;
using KOT.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Player : Element
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("MyMonster")]
    public Monster? MyMonster { get; set; }

    public Player(string name, Monster? monster)
    {
        Name = name;
        MyMonster = monster;
    }
}
